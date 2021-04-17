using AgileDotNetHtml.Models;
using Microsoft.AspNetCore.Html;
using System;

namespace AgileDotNetHtml.Interfaces
{
	public interface IHtmlNodeElement
	{
        IHtmlElementsCollection Children { get; }
        void Text(string html, string afterElementUId, bool decode = false);
        void Text(HtmlString html, string afterElementUId, bool decode = false);
        HtmlNodeElementText[] Texts();
        IHtmlElement FindFirst(Func<IHtmlElement, bool> predicate);
        IHtmlElement FindLast(Func<IHtmlElement, bool> predicate);
        IHtmlElementsCollection FindAll(Func<IHtmlElement, bool> predicate);
    }
}
