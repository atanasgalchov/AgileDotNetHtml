using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("b")]
	public class HtmlBElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlBElement class represent HTML &lt;b&gt; tag.
		/// </summary>
		public HtmlBElement() : base("b") { }
	}
}

