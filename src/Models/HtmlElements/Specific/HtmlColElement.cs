using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("col")]
	public class HtmlColElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlColElement class represent HTML &lt;col&gt; tag.
		/// </summary>
		public HtmlColElement() : base("col") { }
	}
}

