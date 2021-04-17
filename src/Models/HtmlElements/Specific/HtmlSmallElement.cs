using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("small")]
	public class HtmlSmallElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlSmallElement class represent HTML &lt;small&gt; tag.
		/// </summary>
		public HtmlSmallElement() : base("small") { }
	}
}

