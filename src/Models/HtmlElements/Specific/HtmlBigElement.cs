using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("big")]
	public class HtmlBigElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlBigElement class represent HTML &lt;big&gt; tag.
		/// </summary>
		public HtmlBigElement() : base("big") { }
	}
}

