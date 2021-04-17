using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("param")]
	public class HtmlParamElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlParamElement class represent HTML &lt;param&gt; tag.
		/// </summary>
		public HtmlParamElement() : base("param") { }
	}
}

