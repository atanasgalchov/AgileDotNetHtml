using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("meta")]
	public class HtmlMetaElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlMetaElement class represent HTML &lt;meta&gt; tag.
		/// </summary>
		public HtmlMetaElement() : base("meta") { }
	}
}

