using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	internal class HtmlCodeElementFactory : HtmlPairTagsElementFactory
	{
		internal HtmlCodeElementFactory() : base("code")
		{
		}

		public override IHtmlElement Create(HtmlAttributesCollection attributes, string html, int startContentIndex, int endContentIndex, IHtmlParserManager htmlParserManager)
		{
			HtmlCodeElement element = new HtmlCodeElement();
			element.Attributes = attributes;
			element.Text(html.SubStringToIndex(startContentIndex, endContentIndex - 1), true);
			return element;
		}
	}
}
