using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("a")]
	public class HtmlAElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlAElement class represent HTML &lt;a&gt; tag.
		/// </summary>
		public HtmlAElement() : base("a") { }
	}
}

