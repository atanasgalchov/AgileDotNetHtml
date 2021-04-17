using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("summary")]
	public class HtmlSummaryElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlSummaryElement class represent HTML &lt;summary&gt; tag.
		/// </summary>
		public HtmlSummaryElement() : base("summary") { }
	}
}

