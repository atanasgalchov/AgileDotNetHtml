using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("source")]
	public class HtmlSourceElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlSourceElement class represent HTML &lt;source&gt; tag.
		/// </summary>
		public HtmlSourceElement() : base("source") { }
	}
}

