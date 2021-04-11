using AgileDotNetHtml.Interfaces;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileDotNetHtml.Models.HtmlElements
{
	public class HtmlPairTagsElement : HtmlElement, IHtmlPairTagsElement
	{
        protected HtmlString _text;

        public HtmlPairTagsElement(string tagName) : base(tagName) 
        {
        }
        public HtmlPairTagsElement(string tagName, string text) : this(tagName)
        {
            Text(text);
        }
        public virtual HtmlString Text()
        {
            return _text;
        }
        public void Text(string html, bool decode = false)
        {
            if (decode)
                html = HttpUtility.HtmlDecode(html);

            _text = new HtmlString(html);
        }
        public void Text(HtmlString html, bool decode = false)
        {
            if (decode)
                _text = new HtmlString(HttpUtility.HtmlDecode(html.Value));
            else
                _text = html;
        }
    }
}
