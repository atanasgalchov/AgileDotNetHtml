using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("rt")]
	public class HtmlRtElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlRtElement class represent HTML &lt;rt&gt; tag.
		/// </summary>
		public HtmlRtElement() : base("rt") { }
	}
}

