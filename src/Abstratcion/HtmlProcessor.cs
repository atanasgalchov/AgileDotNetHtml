using AgileDotNetHtml.Extensions;
using AgileDotNetHtml.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AgileDotNetHtml.Abstratcion
{
	public class HtmlProcessor
    {
        protected IHtmlStandarts _htmlStandarts;

        /// <summary>
        /// Ctor expect actual state on HTML standarts.
        /// </summary>
        /// <param name="htmlStandarts">Object with HTML standarts.</param>
        public HtmlProcessor(IHtmlStandarts htmlStandarts)
        {
            _htmlStandarts = htmlStandarts;
        }

        public string GetStartSelfClosingHtmlTag(string tagName) => $"<{TrimHtmlTag(tagName)} />";
        public string GetStartHtmlTag(string tagName) => IsSelfClosingHtmlTag(tagName) ? GetStartSelfClosingHtmlTag(tagName) : $"<{TrimHtmlTag(tagName)}>";
        public string GetEndHtmlTag(string tagName) => IsSelfClosingHtmlTag(tagName) ? String.Empty : $"</{TrimHtmlTag(tagName)}>";
        public string TrimHtmlTag(string tagName) => Regex.Replace(tagName, @"\s+|/+", "").TrimStart('<').TrimEnd('>');
        public bool IsValidHtmlTag(string tagName) => _htmlStandarts.AllTags.Any(x => TrimHtmlTag(x).IsEqualIgnoreCase(tagName));
        public bool IsSelfClosingHtmlTag(string tagName) => _htmlStandarts.SelfClosingTags.Any(x => TrimHtmlTag(x).IsEqualIgnoreCase(tagName));
        public bool IsValidHtmlAttribute(string attributeName) => attributeName.StartsWith("data") || _htmlStandarts.AttributeTags.ContainsKey(attributeName);
        public bool IsValidHtmlAttributeForTag(string attributeName, string tagName)
            => attributeName.StartsWith("data") || (_htmlStandarts.AttributeTags.ContainsKey(attributeName) &&
            (_htmlStandarts.AttributeTags[attributeName].IsNullOrEmpty() || _htmlStandarts.AttributeTags[attributeName].Any(x => TrimHtmlTag(x).IsEqualIgnoreCase(tagName))));
    }
}
