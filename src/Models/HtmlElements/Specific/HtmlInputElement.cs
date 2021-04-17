using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("input")]
	public class HtmlInputElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlInputElement class represent HTML &lt;input&gt; tag.
		/// </summary>
		public HtmlInputElement() : base("input") { }
	}
}

