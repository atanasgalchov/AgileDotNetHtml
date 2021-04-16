using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	internal class HtmlStyleElementFactory : HtmlPairTagsElementFactory
	{
		internal HtmlStyleElementFactory() : base("style")
		{
		}

		public override IHtmlElement Create(HtmlAttributesCollection attributes, string html, int startContentIndex, int endContentIndex, IHtmlParserManager htmlParserManager)
		{
			HtmlStyleElement element = new HtmlStyleElement();
			element.Attributes = attributes;
			element.Text(html.SubStringToIndex(startContentIndex, endContentIndex - 1), true);
			return element;
		}
	}
}
