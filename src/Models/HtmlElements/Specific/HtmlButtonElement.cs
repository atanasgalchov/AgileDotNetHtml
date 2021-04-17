using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("button")]
	public class HtmlButtonElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlButtonElement class represent HTML &lt;button&gt; tag.
		/// </summary>
		public HtmlButtonElement() : base("button") { }
	}
}

