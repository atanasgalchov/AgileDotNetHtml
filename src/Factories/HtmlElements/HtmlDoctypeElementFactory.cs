using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	public class HtmlDoctypeElementFactory : HtmlSelfClosingTagElementFactory
	{
		public HtmlDoctypeElementFactory(): base("!DOCTYPE")
		{
		}

		public override IHtmlElement Create(HtmlAttributesCollection attributes, string html, HtmlParserManager htmlParserManager)
		{
			HtmlDoctypeElement document = new HtmlDoctypeElement();
			document.Attributes = attributes;
			return document;
		}
	}
}
