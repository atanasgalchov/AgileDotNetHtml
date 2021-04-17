using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("section")]
	public class HtmlSectionElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlSectionElement class represent HTML &lt;section&gt; tag.
		/// </summary>
		public HtmlSectionElement() : base("section") { }
	}
}

