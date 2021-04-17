using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Helpers;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using AgileDotNetHtml.Models.HtmlElements;

namespace AgileDotNetHtml
{
    public class HtmlBuilder : IHtmlBuilder
    {
        private HtmlHelper _htmlHelper;
        
        /// <summary>
        /// Initialize a new instance of AgileDotNetHtml.HtmlBuilder class.
        /// </summary>
        public HtmlBuilder()
		{
            _htmlHelper = new HtmlHelper();
        }
        /// <summary>
        /// Initialize a new instance of AgileDotNetHtml.HtmlBuilder class with specific self closing html tags names.
        /// </summary>
        /// <param name="selfClosingHtmlTagsNames">The names of selfclosing tags.</param>
        public HtmlBuilder(string[] selfClosingHtmlTagsNames)
        {
            _htmlHelper = new HtmlHelper(selfClosingHtmlTagsNames);
        }

        /// <summary>
        /// Create html attribute string.
        /// </summary>
        /// <param name="attribute">Object of type IHtmlAttribute, for convert to html attribute string.</param>
        /// <returns>String represent specified atribute.</returns>
        public string CreateAtribute(IHtmlAttribute attribute)
        {
            string attributesString = String.Empty;
            if (attribute.Value == null)
            {
                attributesString += $"{attribute.Name} ";
            }
            else
            {
                if ((attribute.Value.StartsWith("'") && attribute.Value.EndsWith("'")) || (attribute.Value.StartsWith("\"") && attribute.Value.EndsWith("\"")) || attribute.WrapValueQuote == null)
                    attributesString += $"{attribute.Name}={attribute.Value} ";
                else
                    attributesString += $"{attribute.Name}={attribute.WrapValueQuote}{attribute.Value}{attribute.WrapValueQuote} ";
            }

            return attributesString.TrimEnd().TrimStart();
        }
        /// <summary>
        /// Create html start tag string.
        /// </summary>
        /// <param name="tagName">The name of html tag.</param>
        /// <returns>String represet given start html tag.</returns>
        public string CreateStartTag(string tagName) => _htmlHelper.IsSelfClosingHtmlTag(tagName) ? CreateStartSelfClosingTag(tagName) : $"<{_htmlHelper.TrimHtmlTag(tagName)}>";
        /// <summary>
        /// Create html start self closing tag string.
        /// </summary>
        /// <param name="tagName">The name of html tag.</param>
        /// <returns>String represet given html tag.</returns>
        public string CreateStartSelfClosingTag(string tagName) => $"<{_htmlHelper.TrimHtmlTag(tagName)}>";
        /// <summary>
        /// Create html end tag string.
        /// </summary>
        /// <param name="tagName">The name of html tag.</param>
        /// <returns>String represet given html end tag.</returns>
        public string CreateEndTag(string tagName) => _htmlHelper.IsSelfClosingHtmlTag(tagName) ? String.Empty : $"</{_htmlHelper.TrimHtmlTag(tagName)}>";
        /// <summary>
        /// Create html content.
        /// </summary>
        /// <param name="htmlElements">Collection of type IHtmlElement, for convert to HTML content.</param>
        /// <returns>Html content repsresent specified elements collection.</returns>
        public IHtmlContent CreateHtmlContent(IHtmlElementsCollection htmlElements)
            => new HtmlString(String.Join("", htmlElements.Select(element =>  CreateHtmlContent(element))));
        /// <summary>
        /// Create html content.
        /// </summary>
        /// <param name="htmlElement">Object of type IHtmlElement, for convert to standart HTML content.</param>
        /// <returns>Html content repsresent specified tag.</returns>
        public virtual IHtmlContent CreateHtmlContent(IHtmlElement htmlElement) 
        {
            if (htmlElement is HtmlSelfClosingTagElement)
                return CreateHtmlContent((HtmlSelfClosingTagElement)htmlElement);
            else if(htmlElement is HtmlNodeElement)
                return CreateHtmlContent((HtmlNodeElement)htmlElement);
            else if(htmlElement is HtmlDocument)
                return CreateHtmlContent((HtmlDocument)htmlElement);
        
            return CreateHtmlContent((HtmlPairTagsElement)htmlElement);
        }
        /// <summary>
        /// Create html content.
        /// </summary>
        /// <param name="htmlDocument">Object of type HtmlDocument, for convert to standart HTML document content.</param>
        /// <returns>Html content repsresent specified document.</returns>
        public IHtmlContent CreateHtmlContent(HtmlDocument htmlDocument) 
        {
            IHtmlContent doctype = CreateHtmlContent(htmlDocument.Doctype);
            IHtmlContent html = CreateHtmlContent((HtmlNodeElement)htmlDocument);
         
            return new HtmlString($"{doctype}\r\n{html}");
        }
        /// <summary>
        /// Create html content.
        /// </summary>
        /// <param name="htmlElement">Object of type HtmlNodeElement, for convert to standart HTML document content.</param>
        /// <returns>Html content repsresent specified node element.</returns>
        public IHtmlContent CreateHtmlContent(HtmlNodeElement htmlElement)
        {
            if (htmlElement.Children.IsNullOrEmpty())
                return new HtmlString(
                    $"{CreateStartTag(htmlElement.TagName)}{htmlElement.Text()}{CreateEndTag(htmlElement.TagName)}"
                        .Insert((htmlElement.TagName.Length + 1), htmlElement.Attributes.IsNullOrEmpty() ? "" : $" {String.Join(" ", htmlElement.Attributes.Select(x => CreateAtribute(x)))}"));

            List<IHtmlContent> childContents = new List<IHtmlContent>();
            List<HtmlNodeElementText> knownPossitionedTexts = new List<HtmlNodeElementText>();
            foreach (var text in htmlElement.Texts())
            {
                if (text.AfterElementUId == null || !htmlElement.Children.Any(x => x.UId == text.AfterElementUId))
                    childContents.Add(text.HtmlString);
                else
                    knownPossitionedTexts.Add(text);
            }

            foreach (var child in htmlElement.Children)
            {
                childContents.Add(CreateHtmlContent(child));
                if (knownPossitionedTexts.Any(x => x.AfterElementUId == child.UId))
                    childContents.Add(knownPossitionedTexts.FirstOrDefault(x => x.AfterElementUId == child.UId).HtmlString);
            }

            return new HtmlString(
                    $"{CreateStartTag(htmlElement.TagName)}{String.Join("", childContents.Select(x => x.ToString()).ToArray())}{CreateEndTag(htmlElement.TagName)}"
                        .Insert((htmlElement.TagName.Length + 1), htmlElement.Attributes.IsNullOrEmpty() ? "" : $" {String.Join(" ", htmlElement.Attributes.Select(x => CreateAtribute(x)))}"));
        }
        /// <summary>
        /// Create html content.
        /// </summary>
        /// <param name="htmlElement">Object of type HtmlPairTagsElement, for convert to standart HTML pair tags content.</param>
        /// <returns>Html content repsresent specified pair tags element.</returns>
        public IHtmlContent CreateHtmlContent(HtmlPairTagsElement htmlElement)
        {
            return new HtmlString(
                    $"{CreateStartTag(htmlElement.TagName)}{htmlElement.Text()}{CreateEndTag(htmlElement.TagName)}"
                        .Insert((htmlElement.TagName.Length + 1), htmlElement.Attributes.IsNullOrEmpty() ? "" : $" {String.Join(" ", htmlElement.Attributes.Select(x => CreateAtribute(x)))}"));
        }
        /// <summary>
        /// Create html content.
        /// </summary>
        /// <param name="htmlElement">Object of type HtmlSelfClosingTagElement, for convert to standart HTML self closing tag content.</param>
        /// <returns>Html content repsresent specified self closing tag element.</returns>
        public IHtmlContent CreateHtmlContent(HtmlSelfClosingTagElement htmlElement)
        {
            return new HtmlString(
                    $"{CreateStartTag(htmlElement.TagName)}"
                        .Insert((htmlElement.TagName.Length + 1), htmlElement.Attributes.IsNullOrEmpty() ? "" : $" {String.Join(" ", htmlElement.Attributes.Select(x => CreateAtribute(x)))}"));
        }
    }
}
