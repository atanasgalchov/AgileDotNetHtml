using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	public class HtmlCodeElementFactory : HtmlPairTagsElementFactory
	{
		public HtmlCodeElementFactory() : base("code")
		{
		}

		public override IHtmlElement Create(HtmlAttributesCollection attributes, string html, int startContentIndex, int endContentIndex, HtmlParserManager htmlParserManager)
		{
			HtmlPairTagsElement element = new HtmlPairTagsElement(_tagName);
			element.Attributes = attributes;
			element.Text(html.SubStringToIndex(startContentIndex, endContentIndex - 1), true);
			return element;
		}
	}
}
