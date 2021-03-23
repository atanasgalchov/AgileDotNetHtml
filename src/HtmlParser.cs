﻿using AgileDotNetHtml.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AgileDotNetHtml
{
	public class HtmlParser : IHtmlParser
	{
		private HtmlHelper _htmlHelper;
		private string _startTagRegex = "<[!]?[a-zA-Z]+(>|.*?[^?]>)";
		private string _endTagRegex = "((<[\\s]*\\/)[\\s]*\\w+([\\s]*>))";		
		private string _keyValueAttributeRegex = "(\\S+)=[\"']?";

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
			while (keyValueAttributesMatch.Index > 0)
			{				
				string name = keyValueAttributesMatch.Value.Split("=")[0];
				string value = String.Empty;

				// find start attribute value index
				int startValueIndex = 0;
				char startValueQuoteSymbol = '"';
				// skip space and escaping chars
				for (int i = keyValueAttributesMatch.Index + name.Length; i < startTag.Length; i++)
				{
					// when find first quote char, set start value index and break loop
					if (startTag[i] == '\'' || startTag[i] == '"')
					{
						startValueIndex = i;
						startValueQuoteSymbol = startTag[i];
						break;
					}
				}

				
				if (startValueIndex != 0)
				{
					// TODO add check for non value attribute
					// start from point after attribute and go back while find same quote char as start to find endAttribute index
					int endValueIndex = keyValueAttributesMatch.NextMatch().Index > 0 ? keyValueAttributesMatch.NextMatch().Index : startTag.Length - 1;
					for (int i = endValueIndex; i > startValueIndex; i--)
					{
						if (startTag[i] == startValueQuoteSymbol)
						{
							endValueIndex = i;
							break;
						}
					}

					value = startTag.Substring(startValueIndex, (endValueIndex - startValueIndex) + 1)
						.TrimEnd(new char[] { '"', })
						.TrimStart(new char[] { '"', });
				}

				element.AddAttribute(new HtmlAttribute(name, value));

				// match next attribute
				keyValueAttributesMatch = keyValueAttributesMatch.NextMatch();
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
				
				// break if not exist tags
				if (endTagMatch.Index == 0 && startTagMatch.NextMatch().Index == 0)
					break;

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
					// add text if have text before children tags
					if (nextStartTagMatch.Index > 0)
					{
						// add text in element
						element.Text(html.Substring(0, nextStartTagMatch.Index));
						// remove text from html string
						html = html.Remove(0, nextStartTagMatch.Index);
					}

					// match all start tags ignoring self closing tags
					var startTagMatches = new Regex(_startTagRegex)
						.Matches(html)
						.Where(x => !_htmlHelper.IsSelfClosingHtmlTag(GetTagNameFromStartTag(x.Value)));

					// match all end tags
					MatchCollection endTagMatches = new Regex(_endTagRegex).Matches(html);
					// find end tang on current tag
					endTagMatch = endTagMatches
						.FirstOrDefault(endTag => startTagMatches.Count(x => x.Index < endTag.Index) == endTagMatches.Count(x => x.Index < endTag.Index));

					if (endTagMatch == null)
						throw new ArgumentException($"The given html is not valid.Close tag on {startTagMatch.Value} start tag did not found. {html}");

					// get all end root tags
					List<Match> rootEndTagsMatch = endTagMatches
						.Where(endTag => 
							startTagMatches.Count(startTag => startTag.Index < endTag.Index) == endTagMatches.Count(endTag2 => endTag2.Index <= endTag.Index)
						).ToList();

					// try find text between root tags
					List<Tuple<string, int>> elementTextsIndexes = new List<Tuple<string, int>>();
					List<Tuple<int, int>> textsIndexLength = new List<Tuple<int, int>>();
					foreach (var rootEndTag in rootEndTagsMatch)
					{
						Match startTagAfterEndTag = startTagMatches.FirstOrDefault(x => x.Index > rootEndTag.Index && x.Index < endTagMatch.Index);
						
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
					element.Children = _ParseString(html.Substring(0, endTagMatch.Index - elementTextsIndexes.Sum(x => x.Item1.Length)));

					// set text
					foreach (var textIndex in elementTextsIndexes)					
						element.Text(textIndex.Item1, textIndex.Item2 > 0 ? element.Children[textIndex.Item2 - 1].UId : null);
					
					// remove children part and closing tag from html string
					html = html.Substring((endTagMatch.Index - elementTextsIndexes.Sum(x => x.Item1.Length)) + endTagMatch.Value.Length);
				}
			}

			return htmlElements;
		}
	}
}
