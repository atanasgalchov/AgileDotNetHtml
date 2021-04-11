using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	public class HtmlPairTagsElementFactory : IHtmlPairTagsElementFactory
	{
		protected string _tagName;

		public HtmlPairTagsElementFactory(string tagName)
		{
			_tagName = tagName;
		}

		public virtual IHtmlElement Create(HtmlAttributesCollection attributes, string html, int startContentIndex, int endContentIndex, HtmlParserManager htmlParserManager)
		{
			HtmlPairTagsElement element = new HtmlPairTagsElement(_tagName);
			element.Attributes = attributes;
			element.Text(html.SubStringToIndex(startContentIndex, endContentIndex - 1));
			return element;
		}
	}
}
