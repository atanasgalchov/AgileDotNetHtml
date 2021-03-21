using AgileDotNetHtml.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public string CreateStartSelfClosingTag(string tagName) => $"<{_htmlHelper.TrimHtmlTag(tagName)} />";
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
            => new HtmlString(String.Join("", htmlElements.Select(element =>  _CreateHtmlContent(element))));
        /// <summary>
        /// Create html content.
        /// </summary>
        /// <param name="htmlElement">Object of type IHtmlElement, for convert to standart HTML content.</param>
        /// <returns>Html content repsresent specified tag.</returns>
        public IHtmlContent CreateHtmlContent(IHtmlElement htmlElement) => _CreateHtmlContent(htmlElement);
        /// <summary>
        /// Create html attribute string.
        /// </summary>
        /// <param name="attribute">Object of type IHtmlAttribute, for convert to html attribute string.</param>
        /// <returns>String represent specified atribute.</returns>
        public string CreateAtribute(IHtmlAttribute attribute)
        {
            string attributesString = String.Empty;
            if (attribute.Value == null)
                attributesString += $"{attribute.Name} ";
            else
                attributesString += $"{attribute.Name}=\"{attribute.Value}\" ";

            return attributesString.TrimEnd().TrimStart();
        }
        /// <summary>
        /// Create HtmlContent from object of type IHtmlElement recursively.
        /// </summary>
        private IHtmlContent _CreateHtmlContent(IHtmlElement htmlElement)
        {
            if (htmlElement.Children.IsNullOrEmpty())
                return new HtmlString(
                    $"{CreateStartTag(htmlElement.TagName)}{htmlElement.Text()}{CreateEndTag(htmlElement.TagName)}"
                        .Insert((htmlElement.TagName.Length + 1), htmlElement.Attributes.IsNullOrEmpty() ? "" : $" {String.Join(" ", htmlElement.Attributes.Select(x=> CreateAtribute(x)))}"));

            List<IHtmlContent> childContents = new List<IHtmlContent>();
            HtmlElementText[] elementTexts = htmlElement.Texts();

            for (int i = 0; i < (htmlElement.Children.Count + elementTexts.Length); i++)
			{
                if (elementTexts.Any(x => x.Index == i))
                    childContents.Add(elementTexts.FirstOrDefault(x => x.Index == i).HtmlString);
                else
                    childContents.Add(_CreateHtmlContent(htmlElement.Children[i]));
            }

            return new HtmlString(
                    $"{CreateStartTag(htmlElement.TagName)}{String.Join("", childContents.Select(x => x.ToString()).ToArray())}{CreateEndTag(htmlElement.TagName)}"
                        .Insert((htmlElement.TagName.Length + 1), $" {String.Join(" ", htmlElement.Attributes.Select(x => CreateAtribute(x)))}"));
        }      
    }
}
