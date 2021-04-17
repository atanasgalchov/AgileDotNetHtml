using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("header")]
	public class HtmlHeaderElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlHeaderElement class represent HTML &lt;header&gt; tag.
		/// </summary>
		public HtmlHeaderElement() : base("header") { }
	}
}

