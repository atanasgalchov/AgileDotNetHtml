using AgileDotNetHtml.Factories.HtmlAttributes;
using AgileDotNetHtml.Factories.HtmlElements;
using AgileDotNetHtml.Helpers;
using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using AgileDotNetHtml.Models.HtmlAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AgileDotNetHtml.Factories
{
	public class HtmlParserManager
	{
		internal const string startTagRegex = "(<[!]?[a-zA-Z\\d]+)(>|.*?[^?]>)";
		internal const string selfClosingTagEnds = "[/][\\s]*>";
		internal const string endTagRegex = "((<[\\s]*\\/)[\\s]*\\w+([\\s]*>))";
		internal const string wholeTagRegex = "(<[!]?[a-zA-Z]+)(>|.*?[^?]>).*((<[\\s]*/)[\\s]*\\w+([\\s]*>))";
		internal const string keyValueAttributeEqualSymbolSpacingRegex = "[\\s]+=[\\s]+";
		internal const string commentRegex = "<!--[\\s\\S]*?-->";
		internal const string keyValueAttributeRegex = "(\\S+)=[\"']?((?:.(?![\"']?\\s+(?:\\S+)=|[>\"']))+.)[\"']?";
		private HtmlHelper _htmlHelper;
		private string _html;
		private List<Match> _startTagsMathes;
		private List<Match> _pairStartTagsMathes;
		private List<Match> _endTagsMathes;

		public HtmlParserManager(string html)
		{
			_htmlHelper = new HtmlHelper();
			_html = html;
			
			// trim string
			_html = _html.TrimStart().TrimEnd();
			// encode all tags whit potantial tags inside which is not part of html tree sctrucure
			_html = EncodeTagsContent(_htmlHelper.TagsWhitPotentialInvalidHtmlInside, _html);
			_html = EncodeCommentsContent(_html);
			_html = EncodeAttributesValue(_html);
			// ensure tags which is can be self closing and can have closing tag
			_html = EnsurSelfClosingTags(_html);

			_startTagsMathes = Regex.Matches(_html, startTagRegex, RegexOptions.Singleline)
				.ToList();
			_pairStartTagsMathes = _startTagsMathes
				.Where(x => !_htmlHelper.IsSelfClosingHtmlTag(_htmlHelper.ExtractTagNameFromStartTag(x.Value)))
				.ToList();
			_endTagsMathes = Regex.Matches(_html, endTagRegex)
				.ToList();

			if (_pairStartTagsMathes.Count != _endTagsMathes.Count) 
			{
				var startTags = _pairStartTagsMathes.Select(x => _htmlHelper.ExtractTagNameFromStartTag(x.Value)).ToArray().Distinct();
				var endTags = _endTagsMathes.Select(x => _htmlHelper.ExtractTagNameFromEndTag(x.Value)).ToArray().Distinct();
				var groupedStartTags = startTags.GroupBy(st => st, (key, g) => new { TagName = key, Count = g.Count() });
				var groupedEndTags = endTags.GroupBy(st => st, (key, g) => new { TagName = key, Count = g.Count() });

				string message = "";
				if (startTags.Count() > endTags.Count())
				{			
					var invalidTags = groupedStartTags
					   .Where(x => !endTags.Any(e => e == x.TagName) || x.Count != groupedEndTags.FirstOrDefault(ge => ge.TagName == x.TagName).Count)
					   .Select(x => x.TagName)
					   .ToList();
					message = String.Format("Invalid HTML string, the count of open tags is greater  than closed tags. Invalid tags: {0}", String.Join(",", invalidTags));
				}
				else 
				{
				
					var invalidTags = groupedEndTags
					   .Where(x => !startTags.Any(e => e == x.TagName) || x.Count != groupedStartTags.FirstOrDefault(ge => ge.TagName == x.TagName).Count)
					   .Select(x => x.TagName)
					   .ToList();
					message = String.Format("Invalid HTML  string, the count of open tags is less than closed tags. Invalid tags: {0}", String.Join(",", invalidTags));
				}

				throw new ArgumentException(message, "html");
			}
		}

		public IHtmlElementsCollection Parse() 
		{
			return Parse(0, _html.Length);
		}
		public IHtmlElementsCollection Parse(int startIndex, int endIndex)
		{
			IHtmlElementsCollection elements = new HtmlElementsCollection();

			// get all matches in current range
			List<Match> startTagMatchesInCurrentRange = _startTagsMathes.Where(x => x.Index >= startIndex && x.Index < endIndex).ToList();
			List<Match> pairStartTagMatchesInCurrentRange = _pairStartTagsMathes.Where(x => x.Index >= startIndex && x.Index < endIndex).ToList();
			List<Match> endTagMatchesInCurrentRange = _endTagsMathes.Where(x => x.Index > startIndex && x.Index < endIndex).ToList();
			
			// get root start tags in current range
			List<Match> rootStartTagMatches = startTagMatchesInCurrentRange
				.Where(currentStartTag =>
					pairStartTagMatchesInCurrentRange
						.Count(startTag => startTag.Index < currentStartTag.Index) == endTagMatchesInCurrentRange.Count(endTag => endTag.Index <= currentStartTag.Index)
				)
				.ToList();
			// get root end tags in current range
			List<Match> rootEndTagMatches = endTagMatchesInCurrentRange
				.Where(currentEndTag =>
					pairStartTagMatchesInCurrentRange
						.Count(startTag => startTag.Index < currentEndTag.Index) == endTagMatchesInCurrentRange.Count(endTag2 => endTag2.Index <= currentEndTag.Index)
				)
				.ToList();
			
			// create IHtmlElement for every start tag and add to collection
			foreach (Match startTagMatch in rootStartTagMatches)
			{
				// get tag name
				string tagName = _htmlHelper.ExtractTagNameFromStartTag(startTagMatch.Value);
			
				// parse attributes
				HtmlAttributesCollection attributes = ParseAttributes(startTagMatch.Value);

				// if tag is self closing
				if (_htmlHelper.IsSelfClosingHtmlTag(tagName))
				{
					// create elements factory
					IHtmlSelfClosingTagElementFactory htmlElementsFactory;
					switch (tagName.ToLower())
					{
						case "!doctype":
							htmlElementsFactory = new HtmlDoctypeElementFactory();
							break;
						default:
							htmlElementsFactory = new HtmlSelfClosingTagElementFactory(tagName);
							break;
					}

					// create element
					IHtmlElement element = htmlElementsFactory.Create(attributes, _html, this);
					// add
					elements.Add(element);
				}
				// when tag have pair tags
				else 
				{
					// create elements factory
					IHtmlPairTagsElementFactory htmlElementsFactory;
					switch (tagName.ToLower())
					{
						case "html":
							htmlElementsFactory = new HtmlDocumentElementFactory();
							break;
						case "noscript":
							htmlElementsFactory = new HtmlNoScriptElementFactory();
							break;
						case "script":
							htmlElementsFactory = new HtmlScriptElementFactory();
							break;
						case "style":
							htmlElementsFactory = new HtmlStyleElementFactory();
							break;
						case "code":
							htmlElementsFactory = new HtmlCodeElementFactory();
							break;
						default:
							htmlElementsFactory = new HtmlNodeElementFactory(tagName);
							break;
					}

					// find start content index			
					int startContentIndex = startTagMatch.Index + startTagMatch.Value.Length;

					// find cloing tang on current star tag
					Match endTagMatch = rootEndTagMatches.FirstOrDefault(x => x.Index > startTagMatch.Index);
					// in html may have tags whit not defined end tag, in this case just skip him as set end index to be end index on start tag
					int endContentIndex = startTagMatch.Index + startTagMatch.Value.Length;
					if (endTagMatch != null)
						endContentIndex = endTagMatch.Index;

					// create element
					IHtmlElement element = htmlElementsFactory.Create(attributes, _html, startContentIndex, endContentIndex, this);

					// add
					elements.Add(element);
				}
			}

			return elements;
		}

		public Dictionary<int, string> ParseText(int startIndex, int endIndex)
		{
			if (startIndex == 5) 
			{
			
			}
			// init result dict
			Dictionary<int, string> texts = new Dictionary<int, string>();

			// get all matches in current range
			List<Match> startTagMatchesInCurrentRange = _startTagsMathes.Where(x => x.Index >= startIndex && x.Index < endIndex).ToList();
			List<Match> pairStartTagMatchesInCurrentRange = _pairStartTagsMathes.Where(x => x.Index >= startIndex && x.Index < endIndex).ToList();
			List<Match> endTagMatchesInCurrentRange = _endTagsMathes.Where(x => x.Index > startIndex && x.Index < endIndex).ToList();

			// get root start tags in current range
			List<Match> rootStartTagMatches = startTagMatchesInCurrentRange
				.Where(currentStartTag =>
					pairStartTagMatchesInCurrentRange
						.Count(startTag => startTag.Index < currentStartTag.Index) == endTagMatchesInCurrentRange.Count(endTag => endTag.Index <= currentStartTag.Index)
				)
				.ToList();

			// if no tags add all content as text
			if (rootStartTagMatches.Count == 0) 
			{
				texts.Add(-1, _html.SubStringToIndex(startIndex, endIndex - 1));
				return texts;
			}
			
			// get root self closing tags in current range
			List<Match> rootSelfClosingTagMatches = rootStartTagMatches
				.Where(x => _htmlHelper.IsSelfClosingHtmlTag(_htmlHelper.ExtractTagNameFromStartTag(x.Value)))
				.ToList();

			// get root end tags in current range
			List <Match> rootEndTagMatches = endTagMatchesInCurrentRange
				.Where(currentEndTag =>
					pairStartTagMatchesInCurrentRange
						.Count(startTag => startTag.Index < currentEndTag.Index) == endTagMatchesInCurrentRange.Count(endTag2 => endTag2.Index <= currentEndTag.Index)
				)
				.ToList();

			

			// add text between start index and first tag, whit index zero
			string textBeforeFirstStartTag = _html.SubStringToIndex(startIndex, rootStartTagMatches.FirstOrDefault().Index - 1);
			if (textBeforeFirstStartTag.Length > 0)
				texts.Add(-1, textBeforeFirstStartTag);
			
			// get all text between root tags
			List<Match> rootClosingTagsMatches = rootEndTagMatches;
			rootClosingTagsMatches.AddRange(rootSelfClosingTagMatches);
			rootClosingTagsMatches = rootClosingTagsMatches.OrderBy(x => x.Index).ToList();
			foreach (var closingTag in rootClosingTagsMatches)
			{
				Match nextStartTag = rootStartTagMatches.FirstOrDefault(x => x.Index > closingTag.Index);
				string text = _html.SubStringToIndex(
					closingTag.Index + closingTag.Value.Length, nextStartTag != null ? nextStartTag.Index - 1 : endIndex - 1
				);
				if (text.Length > 0)
					texts.Add(rootClosingTagsMatches.IndexOf(closingTag), text);
			}

			return texts;
		}

		/// <summary>
		/// Create attributes collection including in the start tag string.
		/// </summary>
		/// <param name="startTag">Html start tag string. Example <span id="1">, <div class="div">, ect. </param>
		/// <returns cref="HtmlAttributesCollection">HtmlAttributesCollection whit all found attributes in given start tag.</returns>
		private HtmlAttributesCollection ParseAttributes(string startTag)
		{
			HtmlAttributesCollection attributes = new HtmlAttributesCollection();

			// decode
			startTag = HttpUtility.HtmlDecode(startTag);

			// replace spacing between name-value
			startTag = Regex.Replace(startTag, keyValueAttributeEqualSymbolSpacingRegex, "=");

			// match tag name
			Match startTagMatch = new Regex(startTagRegex).Match(startTag);
			// remove tag name from string
			startTag = startTag.Remove(0, startTagMatch.Groups[1].Value.Length);
			// trim start
			startTag = startTag.TrimEnd(new char[] { '>', '/' }).TrimEnd();

			while (startTag.IsNotNullNorEmpty())
			{
				startTag = startTag.TrimStart();
				// create attribute name
				string attributeName = "";
				for (int i = 0; i < startTag.Length; i++)
				{
					if (startTag[i] == ' ' || startTag[i] == '=')
						break;

					attributeName += startTag[i];
				}

				// create attributes factory
				IHtmlAttributeFactory htmlAttributeFactory;
				switch (attributeName)
				{
					case "style":
						htmlAttributeFactory = new HtmlStyleAttributeFactory();
						break;
					default:
						htmlAttributeFactory = new HtmlAttributeFactory(attributeName);
						break;
				}

				IHtmlAttribute attribute = htmlAttributeFactory.Create(startTag);
				attributes.Add(attribute);

				var endAttributeIndex = startTag.IndexOf(attribute.Name) + attribute.Name.Length;
				if (attribute.Value.IsNotNullNorEmpty())
					endAttributeIndex = startTag.IndexOf(attribute.Value, endAttributeIndex) + attribute.Value.Length;
				else if (startTag.TrimStart().StarstWithPattern(_htmlHelper.GetEmptyValueAttributeRegex(attribute.Name)))
					endAttributeIndex += 3;

				startTag = startTag.Remove(0, endAttributeIndex);
				startTag = startTag.TrimStart().TrimStart(new char[] { '"', '\'' });
			}

			return attributes;
		}
		private string EncodeTagsContent(string[] tagNames, string html)
		{
			foreach (var tagName in tagNames)
			{
				if (Regex.IsMatch(html, _htmlHelper.GetRegexForStartTag(tagName)))
				{
					int offset = 0;
					List<Match> startTagMatches = Regex.Matches(html, _htmlHelper.GetRegexForStartTag(tagName)).ToList();
					List<Match> endTagmatches = Regex.Matches(html, _htmlHelper.GetRegexForEndTag(tagName)).ToList();
					foreach (Match startTagMatch in startTagMatches)
					{
						Match endTagMatch = endTagmatches.FirstOrDefault(x => x.Index > startTagMatch.Index);
						if (endTagMatch.Value != null)
						{
							int startScriptContentIndex = (startTagMatch.Index + startTagMatch.Value.Length) + offset;
							int endScriptContentIndex = endTagMatch.Index + offset;

							string content = html.SubStringToIndex(startScriptContentIndex, endScriptContentIndex - 1);
							string encodedContent = HttpUtility.HtmlEncode(content);

							int noEncodedLength = html.Length;

							html = html.Remove(startScriptContentIndex, endScriptContentIndex - startScriptContentIndex);
							html = html.Insert(startScriptContentIndex, encodedContent);

							offset += html.Length - noEncodedLength;
						}						
					}
				}
			}

			return html;
		}
		private string EncodeCommentsContent(string html)
		{
			if (Regex.IsMatch(html, commentRegex))
			{
				int offset = 0;
				Match commentMatch = Regex.Match(html, commentRegex);
				while (commentMatch.Value.IsNotNullNorEmpty())
				{
					// get start and end comment content index, eg <!--{startCommentContentIndex}Comment...{endCommentContentIndex}-->
					int startCommentContentIndex = (commentMatch.Index + 4) + offset;
					int endCommentContentIndex = ((commentMatch.Index + commentMatch.Value.Length) - 3) + offset;

					string content = html.SubStringToIndex(startCommentContentIndex, endCommentContentIndex);
					string encodedContent = HttpUtility.HtmlEncode(content);

					int noEncodedLength = html.Length;

					html = html.Remove(startCommentContentIndex, (endCommentContentIndex - startCommentContentIndex) + 1);
					html = html.Insert(startCommentContentIndex, encodedContent);

					offset += html.Length - noEncodedLength;

					commentMatch = commentMatch.NextMatch();
				}
			}

			return html;
		}
		private string EncodeAttributesValue(string html)
		{
			if (Regex.IsMatch(html, startTagRegex))
			{
				int offset = 0;
				Match startTagMatch = Regex.Match(html, startTagRegex);
				while (startTagMatch.Value.IsNotNullNorEmpty())
				{
					if (startTagMatch.Value.IndexOf(' ') >= 0 && Regex.IsMatch(startTagMatch.Value, keyValueAttributeRegex))
					{
						// get start and end comment content index, eg <div{startAttributesIndex}Comment...{endCommentContentIndex}
						int startAttributesIndex = (startTagMatch.Index + startTagMatch.Value.IndexOf(' ')) + offset;
						int endAttributesIndex = ((startTagMatch.Index + startTagMatch.Value.Length) - 2) + offset;

						// if before closing bracket have odd number of quotes this mean that is end tag index is incorrect
						// find first closing bracked which have even number of quotes
						if (startTagMatch.Value.ToList().Count(x => x == '"' || x == '\'') % 2 != 0)
						{
							bool foundEndTagIndex = false;
							while (foundEndTagIndex == false)
							{
								if (html[endAttributesIndex + 1] == '>' && html.SubStringToIndex(startTagMatch.Index, endAttributesIndex).Count(x => x == '"' || x == '\'') % 2 == 0)
									foundEndTagIndex = true;
								else
									endAttributesIndex += 1;
							}
						}

						string content = html.SubStringToIndex(startAttributesIndex, endAttributesIndex);
						string encodedContent = HttpUtility.HtmlEncode(content);

						int noEncodedLength = html.Length;

						html = html.Remove(startAttributesIndex, (endAttributesIndex - startAttributesIndex) + 1);
						html = html.Insert(startAttributesIndex, encodedContent);

						offset += html.Length - noEncodedLength;
					}

					startTagMatch = startTagMatch.NextMatch();
				}
			}

			return html;
		}
		private string EnsurSelfClosingTags(string html)
		{
			if (Regex.IsMatch(html, startTagRegex))
			{
				int offset = 0;
				Match startTagMatch = Regex.Match(html, startTagRegex);
				while (startTagMatch.Value.IsNotNullNorEmpty())
				{
					string tagName = _htmlHelper.ExtractTagNameFromStartTag(startTagMatch.Value);
					if (!_htmlHelper.IsSelfClosingHtmlTag(tagName) && startTagMatch.Value.EndstWithPattern(selfClosingTagEnds))
					{
						string endTag = $"</{tagName}>";
						int lengthBeforeInsert = html.Length;
						html = html.Insert(startTagMatch.Index + startTagMatch.Value.Length + offset, endTag);
						offset += html.Length - lengthBeforeInsert;
					}
					else if (_htmlHelper.IsSelfClosingHtmlTag(tagName))
					{					
						Match selfClosingEndTagMatch = Regex.Match(html, _htmlHelper.GetRegexForEndTag(tagName));
						if (selfClosingEndTagMatch.Success && selfClosingEndTagMatch.Index > startTagMatch.Index && selfClosingEndTagMatch.Index < startTagMatch.NextMatch().Index) 
						{
							int lengthBeforeInsert = html.Length;
							html = html.Remove(selfClosingEndTagMatch.Index, selfClosingEndTagMatch.Value.Length);
							offset -= lengthBeforeInsert - html.Length;
						}
					}

					startTagMatch = startTagMatch.NextMatch();
				}
			}

			return html;
		}
	}
}
