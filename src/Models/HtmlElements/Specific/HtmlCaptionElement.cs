using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("caption")]
	public class HtmlCaptionElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlCaptionElement class represent HTML &lt;caption&gt; tag.
		/// </summary>
		public HtmlCaptionElement() : base("caption") { }
	}
}

