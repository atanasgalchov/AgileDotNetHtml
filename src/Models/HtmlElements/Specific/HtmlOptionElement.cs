using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("option")]
	public class HtmlOptionElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlOptionElement class represent HTML &lt;option&gt; tag.
		/// </summary>
		public HtmlOptionElement() : base("option") { }
	}
}

