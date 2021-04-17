using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("br")]
	public class HtmlBrElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlBrElement class represent HTML &lt;br&gt; tag.
		/// </summary>
		public HtmlBrElement() : base("br") { }
	}
}

