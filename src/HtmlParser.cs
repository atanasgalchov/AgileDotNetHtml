using AgileDotNetHtml.ClassFactory;
using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Helpers;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace AgileDotNetHtml
{
	public class HtmlParser : IHtmlParser
	{
		private HtmlHelper _htmlHelper;
		private HttpClient _httpClient;
		/// <summary>
		/// Initialize a new instance of the AgileDotNetHtml.HtmlParser class.
		/// </summary>
		public HtmlParser()
		{
			_htmlHelper = new HtmlHelper();
			_httpClient = HttpClientFactory.Create();
		}
		/// <summary>
		/// Initialize a new instance of the AgileDotNetHtml.HtmlParser class.
		/// </summary>
		/// <param name="httpClientFactory">Instance of IHttpClientFactory for create http client.</param>
		public HtmlParser(IHttpClientFactory httpClientFactory)
		{
			_htmlHelper = new HtmlHelper();
			_httpClient = httpClientFactory.CreateClient();
		}
		
		/// <summary>
		/// Load and convert html document string to HtmlDocument.
		/// </summary>
		/// <param name="html">Valid html document string.</param>
		/// <returns cref="HtmlDocument">HtmlDocument instance represent given html string.</returns>
		public HtmlDocument ParsePageFromUrl(string url) 
		{
			if (url.IsNullOrEmpty())
				throw new ArgumentNullException("url");

			Task<HttpResponseMessage> responseTask = _httpClient.GetAsync(url);
			HttpResponseMessage response = responseTask.Result;
			string content = response.Content.ReadAsStringAsync().Result;

			return ParsePage(content);
		}
		/// <summary>
		/// Convert html document string to HtmlDocument.
		/// </summary>
		/// <param name="html">Valid html document string.</param>
		/// <returns cref="HtmlDocument">HtmlDocument instance represent given html string.</returns>
		public HtmlDocument ParsePage(string html)
		{
			if (html.IsNullOrEmpty())
				throw new ArgumentNullException("html");

			IHtmlElementsCollection elements = ParseString(html);
			HtmlDocument document = (HtmlDocument)elements.FirstOrDefault(x => x.TagName == "html");
			document.Doctype = (HtmlDoctypeElement)elements.FirstOrDefault(x => x.TagName.IsEqualIgnoreCase("!DOCTYPE"));
					
			return document;
		}
		/// <summary>
		/// Try convert html string to IHtmlElementsCollection.
		/// </summary>
		/// <param name="html">Valid html string.</param>
		/// <param name="htmlElements">When the given string is parsed successfully, IHtmlElementsCollection instance represent given html string, otherwise null.</param>
		/// <returns>True, if the given string is parsed successfully, otherwise false.</returns>
		public bool TryParseString(string html, out IHtmlElementsCollection htmlElements) 
		{
			try
			{
				htmlElements = ParseString(html);
				return true;
			}
			catch
			{
				htmlElements = null;
				return false;
			}
		}
		/// <summary>
		/// Convert html string to IHtmlElementsCollection.
		/// </summary>
		/// <param name="html">Valid html string.</param>
		/// <returns cref="IHtmlElementsCollection">IHtmlElementsCollection instance represent given html string.</returns>
		public IHtmlElementsCollection ParseString(string html)
		{
			if(html.IsNullOrEmpty())
				throw new ArgumentNullException("html");

			// trim string
			html = html.TrimStart().TrimEnd();

			// encode all tags whit potantial tags inside which is not part of html tree sctrucure
			html = _htmlHelper.EncodeTagsContent(_htmlHelper.TagsWhitPotentialInvalidHtmlInside, html);
			html = _htmlHelper.EncodeCommentsContent(html);
			html = _htmlHelper.EncodeAttributesValue(html);
			// ensure tags which is can be declared as self closed, but they can have closing tag also
			html = _htmlHelper.EnsurSelfClosingTags(html);

			return _ParseString(html);
		}
		/// <summary>
		/// Create HtmlElement instance whit start tag name.
		/// </summary>
		/// <param name="startTag">Html start tag string. Example <span>, <div class="div">, ect. </param>
		/// <returns cref="IHtmlElement">HtmlElement instance represent given startTag.</returns>
		public IHtmlElement CreateHtmlElementFromStartTag(string startTag) 
		{
			// get tag name
			string tagName = ExtractTagNameFromStartTagString(startTag);

			// create element factory
			IHtmlElementFactory htmlElementsFactory;
			switch (tagName.ToLower())
			{
				case "!doctype":
					htmlElementsFactory = new HtmlDoctypeElementFactory();
					break;
				case "html":
					htmlElementsFactory = new HtmlDocumentElementFactory();
					break;
				default:
					htmlElementsFactory = new HtmlElementFactory(tagName);
					break;
			}
			
			// create HtmlElement
			IHtmlElement element = htmlElementsFactory.Create();
									
			return element;
		}
		/// <summary>
		/// Create attributes collection including in the start tag string.
		/// </summary>
		/// <param name="startTag">Html start tag string. Example <span id="1">, <div class="div">, ect. </param>
		/// <returns cref="HtmlAttributesCollection">HtmlAttributesCollection whit all found attributes in given start tag.</returns>
		public HtmlAttributesCollection ExtractAttributesFromStartTagString(string startTag)
		{
			HtmlAttributesCollection attributes = new HtmlAttributesCollection();

			// decode
			startTag = HttpUtility.HtmlDecode(startTag);

			// replace spacing between name-value
			startTag = Regex.Replace(startTag, HtmlHelper.keyValueAttributeEqualSymbolSpacingRegex, "=");

			// match tag name
			Match startTagMatch = new Regex(HtmlHelper.startTagRegex).Match(startTag);
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
		/// <summary>
		/// Extract tag name string.
		/// </summary>
		/// <param name="startTag">Html start tag string. Example <span>, <div class="div">, ect. </param>
		/// <returns cref="string">Name of given startTag.</returns>
		public string ExtractTagNameFromStartTagString(string startTag)
		{
			// remove start char
			startTag = startTag.Trim().TrimStart('<');
			// get tag name
			return startTag.Split(new char[] { ' ', '/', '>' }).FirstOrDefault();
		}
		/// <summary>
		/// Parse html string recursively.
		/// </summary>
		private IHtmlElementsCollection _ParseString(string html)
		{
			// create empty html collection
			IHtmlElementsCollection htmlElements = new HtmlElementsCollection();
			
			// fill html collection, on loop step add one element in collection
			while (html.IsNotNullNorEmpty())
			{				
				// match start tag
				Match startTagMatch = new Regex(HtmlHelper.startTagRegex).Match(html);

				// ensure string start whit start tag
				html = html.Remove(0, startTagMatch.Index);
				
				// create element
				IHtmlElement element = CreateHtmlElementFromStartTag(startTagMatch.Value);
				element.Attributes = ExtractAttributesFromStartTagString(startTagMatch.Value);
				htmlElements.Add(element);

				// remove start tag from html string
				html = html.Remove(0, startTagMatch.Value.Length);

				// continue if tag is self closing
				if (_htmlHelper.IsSelfClosingHtmlTag(element.TagName)) 
					continue;
								
				// match first end tag
				Match endTagMatch = new Regex(_htmlHelper.GetRegexForEndTag(element.TagName)).Match(html);

				// if tag is style
				if (element.TagName == "style")
				{
					// add text in element
					if (endTagMatch.Index > 0)
						element.Text(html.Substring(0, endTagMatch.Index));

					// remove text and closing tag on current tag from html string
					html = html.Remove(0, endTagMatch.Index + endTagMatch.Value.Length);
					continue;
				}
				// if tag is script/noscript
				if (element.TagName == "script" || element.TagName == "noscript")
				{
					// add text in element
					if (endTagMatch.Index > 0)
						element.Text(HttpUtility.HtmlDecode(html.Substring(0, endTagMatch.Index)));

					// remove text and closing tag on current tag from html string
					html = html.Remove(0, endTagMatch.Index + endTagMatch.Value.Length);
					continue;
				}

				// match next start tag
				Match nextStartTagMatch = new Regex(HtmlHelper.startTagRegex).Match(html);

				// break if not exist any tags
				if (endTagMatch.Index == 0 && startTagMatch.NextMatch().Index == 0)
					break;

				// if tag not contain tags inside. (eg <div>Text</div>)
				if (nextStartTagMatch.Length == 0 || endTagMatch.Index == 0 || endTagMatch.Index < nextStartTagMatch.Index)
				{
					// add text in element
					if (endTagMatch.Index > 0)
						element.Text(HttpUtility.HtmlDecode(html.Substring(0, endTagMatch.Index)));

					// remove text and closing tag on current tag from html string
					html = html.Remove(0, endTagMatch.Index + endTagMatch.Value.Length);
				}
				else
				{
					// add text if have text before children tags
					if (nextStartTagMatch.Index > 0)
					{
						// add text in element
						element.Text(HttpUtility.HtmlDecode(html.Substring(0, nextStartTagMatch.Index)));
						// remove text from html string
						html = html.Remove(0, nextStartTagMatch.Index);
					}
					// match all start tags ignoring self closing tags
					var startTagMatches = new Regex(HtmlHelper.startTagRegex)
						.Matches(html)
						.Where(x => !_htmlHelper.IsSelfClosingHtmlTag(ExtractTagNameFromStartTagString(x.Value)));

					// match all end tags
					MatchCollection endTagMatches = new Regex(HtmlHelper.endTagRegex).Matches(html);
					// find end tang on current tag
					endTagMatch = endTagMatches
						.FirstOrDefault(endTag => startTagMatches.Count(x => x.Index < endTag.Index) == endTagMatches.Count(x => x.Index < endTag.Index));

					if (endTagMatch == null)
						throw new ArgumentException($"The given html is not valid.Close tag on {startTagMatch.Value} start tag did not found . {startTagMatch.Value}{html}");

					// get all root end tags
					List<Match> rootEndTagsMatch = endTagMatches
						.Where(endTag =>
							startTagMatches.Count(startTag => startTag.Index < endTag.Index) == endTagMatches.Count(endTag2 => endTag2.Index <= endTag.Index)
						)
						.ToList();

					// add all root selfclosing tags
					var rootSelfClosingTagMatches = new Regex(HtmlHelper.startTagRegex)
						.Matches(html)
						.Where(selfClosingTag => 
							_htmlHelper.IsSelfClosingHtmlTag(ExtractTagNameFromStartTagString(selfClosingTag.Value))
							&& selfClosingTag.Index < endTagMatch.Index
							&&  startTagMatches.Count(startTag => startTag.Index < selfClosingTag.Index) == endTagMatches.Count(endTag2 => endTag2.Index <= selfClosingTag.Index)
						);				
					rootEndTagsMatch.AddRange(rootSelfClosingTagMatches);
					// order by index
					rootEndTagsMatch = rootEndTagsMatch.OrderBy(x => x.Index).ToList();

					// try find text between root tags
					List<Tuple<string, int>> elementTextsIndexes = new List<Tuple<string, int>>();
					List<Tuple<int, int>> textsIndexLength = new List<Tuple<int, int>>();
					foreach (var rootEndTag in rootEndTagsMatch)
					{
						List<Match> rootStartTagMatches = startTagMatches.ToList();
						rootStartTagMatches.AddRange(rootSelfClosingTagMatches);
						rootStartTagMatches = rootStartTagMatches.OrderBy(x => x.Index).ToList();
						
						Match startTagAfterEndTag = rootStartTagMatches.FirstOrDefault(x => x.Index > rootEndTag.Index && x.Index < endTagMatch.Index);

						int textStringStartIndex = (rootEndTag.Index + rootEndTag.Value.Length);
						int textStringEndIndex = startTagAfterEndTag != null ? startTagAfterEndTag.Index : endTagMatch.Index;
						if (textStringEndIndex - textStringStartIndex > 0)
						{
							// add text and him index
							elementTextsIndexes.Add(
								new Tuple<string, int>(
									html.Substring(rootEndTag.Index + rootEndTag.Value.Length, textStringEndIndex - textStringStartIndex), rootEndTagsMatch.IndexOf(rootEndTag) + 1
								)
							);

							textsIndexLength.Add(
								new Tuple<int, int>(rootEndTag.Index + rootEndTag.Value.Length, textStringEndIndex - textStringStartIndex)
							);
						}
					}

					// remove text from html string
					foreach (var textIndexLength in textsIndexLength)
					{
						int previousTextsLengthSum = textsIndexLength.Where((x, i) => i < textsIndexLength.IndexOf(textIndexLength)).Select(x => x.Item2).Sum();
						html = html.Remove((textIndexLength.Item1 - previousTextsLengthSum), textIndexLength.Item2);
					}

					// add children
					element.Children.AddRange(_ParseString(html.Substring(0, endTagMatch.Index - elementTextsIndexes.Sum(x => x.Item1.Length))));

					// set text
					foreach (var textIndex in elementTextsIndexes)
						element.Text(HttpUtility.HtmlDecode(textIndex.Item1), textIndex.Item2 > 0 ? element.Children[textIndex.Item2 - 1].UId : null);

					// remove children part and closing tag from html string
					html = html.Substring((endTagMatch.Index - elementTextsIndexes.Sum(x => x.Item1.Length)) + endTagMatch.Value.Length).TrimStart().TrimEnd();
				}
			}

			return htmlElements;
		}
	}
}
