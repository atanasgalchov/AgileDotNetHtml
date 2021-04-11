using AgileDotNetHtml.Interfaces;

namespace AgileDotNetHtml.Models.HtmlElements
{
	public class HtmlSelfClosingTagElement : HtmlElement, IHtmlSelfClosingTagElement
	{
		public HtmlSelfClosingTagElement(string tagName) : base(tagName)
		{

		}
    }
}
