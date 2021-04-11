using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	public class HtmlNoScriptElementFactory : HtmlPairTagsElementFactory
	{
		public HtmlNoScriptElementFactory() : base("noscript")
		{
		}

		public override IHtmlElement Create(HtmlAttributesCollection attributes, string html, int startContentIndex, int endContentIndex, HtmlParserManager htmlParserManager)
		{
			HtmlNoScriptElement element = new HtmlNoScriptElement();
			element.Attributes = attributes;
			element.Text(html.SubStringToIndex(startContentIndex, endContentIndex - 1));
			return element;
		}
	}
}
