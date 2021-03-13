using AgileDotNetHtml.Abstratcion;
using AgileDotNetHtml.Extensions;
using AgileDotNetHtml.HtmlAttributes;
using AgileDotNetHtml.Interfaces;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AgileDotNetHtml.Parser
{
	public class HtmlParser : HtmlProcessor, IHtmlParser
	{
		private string _startTagRegex = "<[!]?[a-zA-Z]+(>|.*?[^?]>)";
		private string _endTagRegex = "((<[\\s]*\\/)[\\s]*\\w+([\\s]*>))";
		private string _keyValueAttributeRegex = "(\\S+)=[\"']?((?:.(?![\"']?\\s+(?:\\S+)=|[>\"']))+.)[\"']?";
		
		/// <summary>
		/// Ctor expect actual state on HTML standarts.
		/// </summary>
		/// <param name="htmlStandarts">Object with HTML standarts.</param>
		public HtmlParser(IHtmlStandarts htmlStandarts) : base(htmlStandarts)
		{
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
		/// Parse html string to IHtmlElementsCollection.
		/// </summary>
		/// <param name="html">Html string.</param>
		/// <returns>IHtmlElementsCollection instance represent given html string.</returns>
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
				if (IsSelfClosingHtmlTag(element.TagName))
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
						.Where(x => !IsSelfClosingHtmlTag(GetTagNameFromStartTag(x.Value)));

					MatchCollection endTagMatches = new Regex(_endTagRegex).Matches(html);
					endTagMatch = endTagMatches
						.FirstOrDefault(endTag => startTagMatches.Count(x => x.Index < endTag.Index) == endTagMatches.Count(x => x.Index < endTag.Index));

					if (endTagMatch == null)
						throw new ArgumentException($"The given html is not valid.Close tag on {startTagMatch.Value} start tag did not found. {html}");

					// add text if text is after children tags
					Match lastEndTagBeforeCurrent = endTagMatches?.LastOrDefault(x => x.Index < endTagMatch.Index);
					int stringBetweenLastEndTagBeforeCurrentAndCurrent = 0;
					if (lastEndTagBeforeCurrent != null) 
					{
						stringBetweenLastEndTagBeforeCurrentAndCurrent = endTagMatch.Index - (lastEndTagBeforeCurrent.Index + lastEndTagBeforeCurrent.Value.Length);
						if (stringBetweenLastEndTagBeforeCurrentAndCurrent > 0)
						{
							// add text in element
							element.Text(html.Substring(lastEndTagBeforeCurrent.Index + lastEndTagBeforeCurrent.Value.Length, stringBetweenLastEndTagBeforeCurrentAndCurrent));
							// remove text from html string
							html = html.Remove(lastEndTagBeforeCurrent.Index + lastEndTagBeforeCurrent.Value.Length, stringBetweenLastEndTagBeforeCurrentAndCurrent);							
						}
					}

					// add children
					element.Children = _ParseString(html.Substring(0, endTagMatch.Index - stringBetweenLastEndTagBeforeCurrentAndCurrent));

					// remove children part and closing tag from html string
					html = html.Substring((endTagMatch.Index + endTagMatch.Value.Length) - stringBetweenLastEndTagBeforeCurrentAndCurrent);
				}
			}

			return htmlElements;
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
				if (!IsValidHtmlAttribute(name) || !IsValidHtmlAttributeForTag(name, element.TagName))
					throw new ArgumentException($"'{name}' is not valid attribute for '{ element.TagName}', according Html Standarts version '{_htmlStandarts.HtmlVersion}'");

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
		/// Get tag name.
		/// </summary>
		/// <param name="startTag">Html start tag string. Example <span>, <div class="div">, ect. </param>
		/// <returns>Name of given startTag.</returns>
		private string GetTagNameFromStartTag(string startTag) 
		{
			// remove start char
			startTag = startTag.Trim().TrimStart('<');
			// get tag name
			return startTag.Split(new char[] { ' ', '/', '>' }).FirstOrDefault();
		}
	}
}
