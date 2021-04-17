using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("img")]
	public class HtmlImgElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlImgElement class represent HTML &lt;img&gt; tag.
		/// </summary>
		public HtmlImgElement() : base("img") { }
	}
}

