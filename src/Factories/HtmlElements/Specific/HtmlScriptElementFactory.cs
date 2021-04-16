using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	internal class HtmlScriptElementFactory : HtmlPairTagsElementFactory
	{
		internal HtmlScriptElementFactory() : base("style")
		{
		}

		public override IHtmlElement Create(HtmlAttributesCollection attributes, string html, int startContentIndex, int endContentIndex, IHtmlParserManager htmlParserManager)
		{
			HtmlScriptElement element = new HtmlScriptElement();
			element.Attributes = attributes;
			element.Text(html.SubStringToIndex(startContentIndex, endContentIndex - 1), true);
			return element;
		}
	}
}
