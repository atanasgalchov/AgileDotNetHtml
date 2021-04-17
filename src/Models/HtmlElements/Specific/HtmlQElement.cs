using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("q")]
	public class HtmlQElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlQElement class represent HTML &lt;q&gt; tag.
		/// </summary>
		public HtmlQElement() : base("q") { }
	}
}

