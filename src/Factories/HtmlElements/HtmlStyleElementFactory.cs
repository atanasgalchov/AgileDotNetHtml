using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	class HtmlStyleElementFactory : HtmlPairTagsElementFactory
	{
		public HtmlStyleElementFactory() : base("style")
		{
		}

		public override IHtmlElement Create(HtmlAttributesCollection attributes, string html, int startContentIndex, int endContentIndex, HtmlParserManager htmlParserManager)
		{
			HtmlStyleElement element = new HtmlStyleElement();
			element.Attributes = attributes;
			element.Text(html.SubStringToIndex(startContentIndex, endContentIndex - 1));
			return element;
		}
	}
}
