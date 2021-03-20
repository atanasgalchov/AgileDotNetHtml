using AgileDotNetHtml.Abstratcion;
using AgileDotNetHtml.Extensions;
using AgileDotNetHtml.Interfaces;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AgileDotNetHtml
{
    public class HtmlBuilder : HtmlProcessor, IHtmlBuilder
    {

        /// <summary>
        /// Ctor expect actual state on HTML standarts.
        /// </summary>
        /// <param name="htmlStandarts">Object with HTML standarts.</param>
        public HtmlBuilder(IHtmlStandarts htmlStandarts) : base(htmlStandarts)
        {
        }

        /// <summary>
        /// Create standart HTML content from IHtmlElementsCollection.
        /// </summary>
        /// <param name="htmlElements">Collection of type IHtmlElement, for convert to standart HTML content.</param>
        /// <returns>Standart HTML content repsresent specified elements collection.</returns>
        public IHtmlContent CreateElement(IHtmlElementsCollection htmlElements)
            => new HtmlString(String.Join("", htmlElements.Select(element =>  _CreateElement(element))));

        /// <summary>
        /// Create standart HTML content from IHtmlTag object.
        /// </summary>
        /// <param name="htmlElement">Object of type IHtmlElement, for convert to standart HTML content.</param>
        /// <returns>Standart HTML content repsresent specified tag.</returns>
        public IHtmlContent CreateElement(IHtmlElement htmlElement) => _CreateElement(htmlElement);

        private IHtmlContent _CreateElement(IHtmlElement htmlElement)
        {
            if (!IsValidHtmlTag(htmlElement.TagName))
                throw new ArgumentException(
                    $"{htmlElement.TagName} is not valid HTML tag. Standart html tags are {String.Join(',', _htmlStandarts.AllTags)}, " +
                    $"according Html Standarts version {_htmlStandarts.HtmlVersion}");

            if (htmlElement.Children.IsNullOrEmpty())
                return new HtmlString(
                    $"{GetStartHtmlTag(htmlElement.TagName)}{htmlElement.Text()}{GetEndHtmlTag(htmlElement.TagName)}"
                        .Insert((htmlElement.TagName.Length + 1), htmlElement.Attributes.IsNullOrEmpty() ? "" : $" {GetAttributesAsString(htmlElement)}"));

            var childContents = new List<IHtmlContent>();
            foreach (var child in htmlElement.Children)
                childContents.Add(_CreateElement(child));
            // TODO Refactor, element Text may be more than one
            return new HtmlString(
                    $"{GetStartHtmlTag(htmlElement.TagName)}{String.Join("", childContents.Where((x, i) => i < htmlElement.TextIndex).Select(x => x.ToString()).ToArray())}{htmlElement.Text()}{String.Join("", childContents.Where((x, i) => i >= htmlElement.TextIndex).Select(x => x.ToString()).ToArray())}{GetEndHtmlTag(htmlElement.TagName)}"
                        .Insert((htmlElement.TagName.Length + 1), $" {GetAttributesAsString(htmlElement)}"));
        }
        public string GetAttributesAsString(IHtmlElement htmlTag)
        {
            string attributesString = String.Empty;
            if (htmlTag.Attributes.IsNullOrEmpty())
                return attributesString;

            foreach (var attribute in htmlTag.Attributes)
            {
                if (!IsValidHtmlAttribute(attribute.Name) || !IsValidHtmlAttributeForTag(attribute.Name, htmlTag.TagName))
                    throw new ArgumentException($"'{attribute.Name}' is not valid attribute for '{ htmlTag.TagName}', according Html Standarts version '{_htmlStandarts.HtmlVersion}'");

                if (attribute.Value == null)
                    attributesString += $"{attribute.Name} ";
                else
                    attributesString += $"{attribute.Name}=\"{attribute.Value}\" ";
            }

            return attributesString.TrimEnd().TrimStart();
        }
    }
}
