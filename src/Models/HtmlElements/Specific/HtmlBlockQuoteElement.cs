using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("blockquote")]
	public class HtmlBlockQuoteElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlBlockQuoteElement class represent HTML &lt;blockquote&gt; tag.
		/// </summary>
		public HtmlBlockQuoteElement() : base("blockquote") { }
	}
}

