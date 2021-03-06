using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("title")]
	public class HtmlTitleElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlTitleElement class represent HTML &lt;title&gt; tag.
		/// </summary>
		public HtmlTitleElement() : base("title") { }
	}
}

