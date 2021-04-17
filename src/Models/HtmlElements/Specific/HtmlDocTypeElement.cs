using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("!DOCTYPE")]
	public class HtmlDocTypeElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlDocTypeElement class represent HTML &lt;!DOCTYPE&gt; tag.
		/// </summary>
		public HtmlDocTypeElement() : base("!DOCTYPE")
		{
		}
	}
}
