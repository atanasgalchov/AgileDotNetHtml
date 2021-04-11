using AgileDotNetHtml.Factories;
using AgileDotNetHtml.Models.HtmlAttributes;

namespace AgileDotNetHtml.Interfaces
{
	public interface IHtmlSelfClosingTagElementFactory
	{
		IHtmlElement Create(HtmlAttributesCollection attributes, string html, HtmlParserManager htmlParserManager);
	}
}
