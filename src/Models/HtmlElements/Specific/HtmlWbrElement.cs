using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("wbr")]
	public class HtmlWbrElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlWbrElement class represent HTML &lt;wbr&gt; tag.
		/// </summary>
		public HtmlWbrElement() : base("wbr") { }
	}
}