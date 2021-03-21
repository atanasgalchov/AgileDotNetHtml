using AgileDotNetHtml.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AgileDotNetHtml
{
	public class HtmlParser : IHtmlParser
	{
		private HtmlHelper _htmlHelper;
		private string _startTagRegex = "<[!]?[a-zA-Z]+(>|.*?[^?]>)";
		private string _endTagRegex = "((<[\\s]*\\/)[\\s]*\\w+([\\s]*>))";
		private string _keyValueAttributeRegex = "(\\S+)=[\"']?((?:.(?![\"']?\\s+(?:\\S+)=|[>\"']))+.)[\"']?";

		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.HtmlParser class.
		/// </summary>
		public HtmlParser()
		{
			_htmlHelper = new HtmlHelper();
		}
		
		/// <summary>
		/// Parse html string to IHtmlElementsCollection.
		/// </summary>
		/// <param name="html">Valid html string.</param>
		/// <returns>IHtmlElementsCollection instance represent given html string.</returns>
		public IHtmlElementsCollection ParseString(string html)
		{
			if(html.IsNullOrEmpty())
				throw new ArgumentNullException("html");

			return _ParseString(html);
		}
		/// <summary>
		/// Create HtmlElement instance.
		/// </summary>
		/// <param name="startTag">Html start tag string. Example <span>, <div class="div">, ect. </param>
		/// <returns>HtmlElement instance represent given startTag.</returns>
		private HtmlElement CreateElementFromStartTag(string startTag) 
		{
			// get tag name
			string tagName = GetTagNameFromStartTag(startTag);
			// create HtmlElement
			HtmlElement element = new HtmlElement(tagName);

			// add all key value attributes
			Match keyValueAttributesMatch = new Regex(_keyValueAttributeRegex).Match(startTag);
			while (keyValueAttributesMatch.Value.IsNotNullNorEmpty())
			{
				// add key value attribute to element
				string name = Regex.Unescape(keyValueAttributesMatch.Value.Split("=")[0].Replace("\"", ""));
				string value = Regex.Unescape(keyValueAttributesMatch.Value.Split("=")[1].Replace("\"", ""));

				element.AddAttribute(new HtmlAttribute(name, value));

				// remove key value attribute from start tag string
				startTag = startTag.Remove(keyValueAttributesMatch.Index, keyValueAttributesMatch.Value.Length);

				// match next attribute
				keyValueAttributesMatch = new Regex(_keyValueAttributeRegex).Match(startTag);
			}
			// TODO Find Regex for such kind attributes
			// add all attributes whitout value
			//foreach (var attribute in _htmlStandarts.AttributeTags.Select(x => x.Key).Where(x => startTag.IndexOf(x) > 0))		
			//	element.AddAttribute(new HtmlAttribute(attribute));
			
			return element;
		}
		/// <summary>
		/// Get tag name string.
		/// </summary>
		/// <param name="startTag">Html start tag string. Example <span>, <div class="div">, ect. </param>
		/// <returns>Name of given startTag.</returns>
		public string GetTagNameFromStartTag(string startTag)
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
				Match startTagMatch = new Regex(_startTagRegex).Match(html);

				// create element
				HtmlElement element = CreateElementFromStartTag(startTagMatch.Value);
				htmlElements.Add(element);

				// remove start tag from html string
				html = html.Remove(0, startTagMatch.Value.Length);

				// continue if tag is self closing
				if (_htmlHelper.IsSelfClosingHtmlTag(element.TagName))
					continue;

				// match first end tag
				Match endTagMatch = new Regex(_endTagRegex).Match(html);
				// match next start tag
				Match nextStartTagMatch = new Regex(_startTagRegex).Match(html);

				// if tag not contain tags inside. (eg <div>Text</div>)
				if (nextStartTagMatch.Length == 0 || endTagMatch.Index == 0 || endTagMatch.Index < nextStartTagMatch.Index)
				{
					// add text in element
					if (endTagMatch.Index > 0)
						element.Text(html.Substring(0, endTagMatch.Index));

					// remove text and closing tag on current tag from html string
					html = html.Remove(0, endTagMatch.Index + endTagMatch.Value.Length);
				}
				else
				{
					// add text if text is before children tags
					if (nextStartTagMatch.Index > 0)
					{
						// add text in element
						element.Text(html.Substring(0, nextStartTagMatch.Index));
						// remove text from html string
						html = html.Remove(0, nextStartTagMatch.Index);
					}

					// find end tag and add in children all tags before end tag
					var startTagMatches = new Regex(_startTagRegex)
						.Matches(html)
						.Where(x => !_htmlHelper.IsSelfClosingHtmlTag(GetTagNameFromStartTag(x.Value)));

					MatchCollection endTagMatches = new Regex(_endTagRegex).Matches(html);
					endTagMatch = endTagMatches
						.FirstOrDefault(endTag => startTagMatches.Count(x => x.Index < endTag.Index) == endTagMatches.Count(x => x.Index < endTag.Index));

					if (endTagMatch == null)
						throw new ArgumentException($"The given html is not valid.Close tag on {startTagMatch.Value} start tag did not found. {html}");

					// add text if text is after children tags
					Match lastEndTagBeforeCurrent = endTagMatches?.LastOrDefault(x => x.Index < endTagMatch.Index);
					int stringBetweenLastEndTagBeforeCurrentAndCurrentTagIndex = 0;
					string elementText = null;
					if (lastEndTagBeforeCurrent != null)
					{
						stringBetweenLastEndTagBeforeCurrentAndCurrentTagIndex = endTagMatch.Index - (lastEndTagBeforeCurrent.Index + lastEndTagBeforeCurrent.Value.Length);
						if (stringBetweenLastEndTagBeforeCurrentAndCurrentTagIndex > 0)
						{
							// add text in element
							elementText = html.Substring(lastEndTagBeforeCurrent.Index + lastEndTagBeforeCurrent.Value.Length, stringBetweenLastEndTagBeforeCurrentAndCurrentTagIndex);
							// remove text from html string
							html = html.Remove(lastEndTagBeforeCurrent.Index + lastEndTagBeforeCurrent.Value.Length, stringBetweenLastEndTagBeforeCurrentAndCurrentTagIndex);
						}
					}

					// add children
					element.Children = _ParseString(html.Substring(0, endTagMatch.Index - stringBetweenLastEndTagBeforeCurrentAndCurrentTagIndex));

					// set text
					if (elementText.IsNotNullNorEmpty())
						element.Text(elementText, element.Children.Count);

					// remove children part and closing tag from html string
					html = html.Substring((endTagMatch.Index + endTagMatch.Value.Length) - stringBetweenLastEndTagBeforeCurrentAndCurrentTagIndex);

					// match next start tag
					nextStartTagMatch = new Regex(_startTagRegex).Match(html);

					// add text if text is between children tags
					if (nextStartTagMatch.Index > 0)
					{
						// add text in element
						// TODO add text idex
						element.Text(html.Substring(0, nextStartTagMatch.Index));
						// remove text from html string
						html = html.Remove(0, nextStartTagMatch.Index);
					}
				}
			}

			return htmlElements;
		}
	}
}
