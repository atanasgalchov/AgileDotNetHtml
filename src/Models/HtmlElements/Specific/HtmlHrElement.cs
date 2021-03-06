using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("hr")]
	public class HtmlHrElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlHrElement class represent HTML &lt;hr&gt; tag.
		/// </summary>
		public HtmlHrElement() : base("hr") { }
	}
}

