using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("embed")]
	public class HtmlEmbedElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlEmbedElement class represent HTML &lt;embed&gt; tag.
		/// </summary>
		public HtmlEmbedElement() : base("embed") { }
	}
}

