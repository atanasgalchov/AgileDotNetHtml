using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("details")]
	public class HtmlDetailsElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlDetailsElement class represent HTML &lt;details&gt; tag.
		/// </summary>
		public HtmlDetailsElement() : base("details") { }
	}
}

