using AgileDotNetHtml.Helpers.Extensions;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AgileDotNetHtml.Helpers
{
	internal class HtmlHelper
	{
		internal const string startTagRegex = "(<[!]?[a-zA-Z\\d]+)(>|.*?[^?]>)";
		internal const string selfClosingTagEnds = "[/][\\s]*>";
		internal const string endTagRegex = "((<[\\s]*\\/)[\\s]*\\w+([\\s]*>))";
		internal const string wholeTagRegex = "(<[!]?[a-zA-Z]+)(>|.*?[^?]>).*((<[\\s]*/)[\\s]*\\w+([\\s]*>))";
		internal const string keyValueAttributeEqualSymbolSpacingRegex = "[\\s]+=[\\s]+";
		internal const string commentRegex = "<!--[\\s\\S]*?-->";
		internal const string keyValueAttributeRegex = "(\\S+)=[\"']?((?:.(?![\"']?\\s+(?:\\S+)=|[>\"']))+.)[\"']?";

		private string[] _selfClosingTagNames = new string[] 
		{
			"!doctype",
			"area",		
			"base",
			"br",
			"col",
			"embed",
			"hr",
			"img",
			"input",
			"link",
			"meta",
			"param",
			"rb",
			"rt",
			"source",
			"track",
			"wbr"
		};
		private string[] _tagsWhitPotentialInvalidHtmlInside = new string[]
		{
			"script",
			"code"
		};
		internal HtmlHelper()
		{
		}
		internal HtmlHelper(string[] selfClosingTagNames)
		{
			_selfClosingTagNames = selfClosingTagNames;
		}

		internal string[] SelfClosingTagNames 
		{ 
			get { return _selfClosingTagNames; } 
			set { _selfClosingTagNames = value;  } 
		}
		internal string[] TagsWhitPotentialInvalidHtmlInside
		{
			get { return _tagsWhitPotentialInvalidHtmlInside; }
			set { _tagsWhitPotentialInvalidHtmlInside = value; }
		}
		internal bool IsSelfClosingHtmlTag(string tagName) => SelfClosingTagNames.Any(x => TrimHtmlTag(x).IsEqualIgnoreCase(tagName));
		internal string TrimHtmlTag(string tagName) => Regex.Replace(tagName, @"\s+|/+", "").TrimStart('<').TrimEnd('>');
		/// <summary>
		/// Extract tag name string.
		/// </summary>
		/// <param name="startTag">Html start tag string. Example <span>, <div class="div">, ect. </param>
		/// <returns cref="string">Name of given startTag.</returns>
		internal string ExtractTagNameFromStartTag(string startTag)
		{
			// remove start char
			startTag = startTag.Trim().TrimStart('<');
			// get tag name
			return startTag.Split(new char[] { ' ', '/', '>' }).FirstOrDefault();
		}
		internal string EncodeTagsContent(string[] tagNames, string html)
		{
			foreach (var tagName in tagNames)
			{
				if (Regex.IsMatch(html, GetRegexForStartTag(tagName)))
				{
					int offset = 0;
					Match startScriptTag = Regex.Match(html, GetRegexForStartTag(tagName));
					Match endScriptTag = Regex.Match(html, GetRegexForEndTag(tagName));
					while (startScriptTag.Value.IsNotNullNorEmpty())
					{
						int startScriptContentIndex = (startScriptTag.Index + startScriptTag.Value.Length) + offset;
						int endScriptContentIndex = endScriptTag.Index + offset;

						string content = html.SubStringToIndex(startScriptContentIndex, endScriptContentIndex - 1);
						string encodedContent = HttpUtility.HtmlEncode(content);

						int noEncodedLength = html.Length;

						html = html.Remove(startScriptContentIndex, endScriptContentIndex - startScriptContentIndex);
						html = html.Insert(startScriptContentIndex, encodedContent);

						offset = html.Length - noEncodedLength;

						startScriptTag = startScriptTag.NextMatch();
						endScriptTag = endScriptTag.NextMatch();
					}
				}
			}
		
			return html;
		}
		internal string EncodeCommentsContent(string html)
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
		internal string EncodeAttributesValue(string html)
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
		internal string EnsurSelfClosingTags(string html)
		{
			if (Regex.IsMatch(html, startTagRegex))
			{
				int offset = 0;
				Match startTagMatch = Regex.Match(html, startTagRegex);
				while (startTagMatch.Value.IsNotNullNorEmpty())
				{
					string tagName = ExtractTagNameFromStartTag(startTagMatch.Value);
					if (!IsSelfClosingHtmlTag(tagName) && startTagMatch.Value.EndstWithPattern(HtmlHelper.selfClosingTagEnds)) 
					{
						string endTag = $"</{tagName}>";
						int lengthBeforeInsert = html.Length;
						html = html.Insert(startTagMatch.Index + startTagMatch.Value.Length + offset, endTag);
						offset = html.Length - lengthBeforeInsert;
					}

					startTagMatch = startTagMatch.NextMatch();
				}
			}

			return html;
		}
		internal string GetRegexForEndTag(string tagName)
		{
			return "((<[\\s]*\\/)[\\s]*(" + tagName + "){1}([\\s]*>))";
		}
		internal string GetRegexForStartTag(string tagName)
		{
			return "(<[!]?(" + tagName + "){1})(>|.*?[^?]>)";
		}
		internal string GetNameValueAttributeRegex(string name)
		{
			return "(" + name + "[\\s]*=[\\s]*)(['\"])";
		}
		internal string GetEmptyValueAttributeRegex(string name)
		{
			return "(" + name + "[\\s]*=[\\s]*)(['\"][\\s]*['\"])";
		}
	}
}
