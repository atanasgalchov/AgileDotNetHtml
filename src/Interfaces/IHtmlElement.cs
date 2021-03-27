using AgileDotNetHtml.Models;
using Microsoft.AspNetCore.Html;
using System;

namespace AgileDotNetHtml.Interfaces
{
    public interface IHtmlElement
    {
        string UId { get; }
        string TagName { get; }
        IHtmlElementsCollection Children { get; }
        IHtmlElementsCollection Parents { get; }      
        HtmlString Text();
        public void Text(string html);
        void Text(HtmlString html);
        public void Text(string html, string afterElementUId);
        public void Text(HtmlString html, string afterElementUId);
        HtmlElementText[] Texts();
        IHtmlElement Find(Func<IHtmlElement, bool> predicate);
        IHtmlAttribute[] Attributes { get; set; }
        void AddAttribute(IHtmlAttribute attribute);
        void AddAttributeValue(string Name, string Value);
        bool HasAttribute(string Name);
        IHtmlAttribute GetAttribute(string Name);
        void ReplaceAttributeValue(string Name, string Value);
        void RemoveAttribute(string Name);
        void AddRangeAttributes(IHtmlAttribute[] Attributes);
    }
}
