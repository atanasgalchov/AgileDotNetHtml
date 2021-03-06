using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("th")]
	public class HtmlThElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlThElement class represent HTML &lt;th&gt; tag.
		/// </summary>
		public HtmlThElement() : base("th") { }
	}
}

