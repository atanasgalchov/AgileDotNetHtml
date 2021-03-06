using AgileDotNetHtml.Models;
using Microsoft.AspNetCore.Html;
using System;

namespace AgileDotNetHtml.Interfaces
{
    public interface IHtmlElement
    {
        string UId { get; }
        string TagName { get; }
        int TextIndex { get; }
        IHtmlElementsCollection Children { get; }
        IHtmlElementsCollection Parents { get; }
        void Text(HtmlString html);
        HtmlString Text();
        IHtmlElement Find(Func<IHtmlElement, bool> predicate);
        void Append(IHtmlElement element);
        void Prepend(IHtmlElement element);
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
