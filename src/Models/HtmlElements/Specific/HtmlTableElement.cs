using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("table")]
	public class HtmlTableElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlTableElement class represent HTML &lt;table&gt; tag.
		/// </summary>
		public HtmlTableElement() : base("table") { }
	}
}

