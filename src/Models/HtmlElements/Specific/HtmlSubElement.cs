using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("sub")]
	public class HtmlSubElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlSubElement class represent HTML &lt;sub&gt; tag.
		/// </summary>
		public HtmlSubElement() : base("sub") { }
	}
}

