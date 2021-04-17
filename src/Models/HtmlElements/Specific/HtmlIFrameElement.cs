using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("iframe")]
	public class HtmlIFrameElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlIFrameElement class represent HTML &lt;iframe&gt; tag.
		/// </summary>
		public HtmlIFrameElement() : base("iframe") { }
	}
}

