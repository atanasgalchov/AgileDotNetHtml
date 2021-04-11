using AgileDotNetHtml.Models;
using Microsoft.AspNetCore.Html;
using System;

namespace AgileDotNetHtml.Interfaces
{
	public interface IHtmlNodeElement
	{
        IHtmlElementsCollection Children { get; }
        void Text(string html, string afterElementUId);
        void Text(HtmlString html, string afterElementUId);
        HtmlElementText[] Texts();
        IHtmlElement Find(Func<IHtmlElement, bool> predicate);
    }
}
