using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	internal class HtmlNoScriptElementFactory : HtmlPairTagsElementFactory
	{
		internal HtmlNoScriptElementFactory() : base("noscript")
		{
		}

		public override IHtmlElement Create(HtmlAttributesCollection attributes, string html, int startContentIndex, int endContentIndex, IHtmlParserManager htmlParserManager)
		{
			HtmlNoScriptElement element = new HtmlNoScriptElement();
			element.Attributes = attributes;
			element.Text(html.SubStringToIndex(startContentIndex, endContentIndex - 1));
			return element;
		}
	}
}
