using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("area")]
	public class HtmlAreaElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlAreaElement class represent HTML &lt;area&gt; tag.
		/// </summary>
		public HtmlAreaElement() : base("area") { }
	}
}

