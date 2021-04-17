using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("cite")]
	public class HtmlCiteElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlCiteElement class represent HTML &lt;cite&gt; tag.
		/// </summary>
		public HtmlCiteElement() : base("cite") { }
	}
}

