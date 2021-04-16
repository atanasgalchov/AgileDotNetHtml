using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	internal class HtmlDoctypeElementFactory : HtmlSelfClosingTagElementFactory
	{
		internal HtmlDoctypeElementFactory(): base("!DOCTYPE")
		{
		}

		public override IHtmlElement Create(HtmlAttributesCollection attributes, string html, IHtmlParserManager htmlParserManager)
		{
			HtmlDocTypeElement document = new HtmlDocTypeElement();
			document.Attributes = attributes;
			return document;
		}
	}
}
