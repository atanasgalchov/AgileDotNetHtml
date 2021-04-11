using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	public class HtmlSelfClosingTagElementFactory : IHtmlSelfClosingTagElementFactory
	{
		protected string _tagName;
		public HtmlSelfClosingTagElementFactory(string tagName)
		{
			_tagName = tagName;
		}

		public virtual IHtmlElement Create(HtmlAttributesCollection attributes, string html, HtmlParserManager htmlParserManager)
		{
			IHtmlElement element = new HtmlSelfClosingTagElement(_tagName);
			element.Attributes = attributes;
			return element;
		}
	}
}
