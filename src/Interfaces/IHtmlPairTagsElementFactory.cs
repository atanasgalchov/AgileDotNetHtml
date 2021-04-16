using AgileDotNetHtml.Factories;
using AgileDotNetHtml.Models.HtmlAttributes;

namespace AgileDotNetHtml.Interfaces
{
	public interface IHtmlPairTagsElementFactory
	{
		IHtmlElement Create(HtmlAttributesCollection attributes, string html, int startContentIndex, int endContentIndex, IHtmlParserManager htmlParserManager);
	}
}
