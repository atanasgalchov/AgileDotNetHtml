using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("base")]
	public class HtmlBaseElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlBaseElement class represent HTML &lt;base&gt; tag.
		/// </summary>
		public HtmlBaseElement() : base("base") { }
	}
}

