using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("td")]
	public class HtmlTdElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlTdElement class represent HTML &lt;td&gt; tag.
		/// </summary>
		public HtmlTdElement() : base("td") { }
	}
}

