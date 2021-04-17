using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("link")]
	public class HtmlLinkElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlLinkElement class represent HTML &lt;link&gt; tag.
		/// </summary>
		public HtmlLinkElement() : base("link") { }
	}
}

