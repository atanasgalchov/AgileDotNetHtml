using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("strike")]
	public class HtmlStrikeElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlStrikeElement class represent HTML &lt;strike&gt; tag.
		/// </summary>
		public HtmlStrikeElement() : base("strike") { }
	}
}

