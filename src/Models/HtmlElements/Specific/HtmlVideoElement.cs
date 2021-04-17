using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("video")]
	public class HtmlVideoElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlVideoElement class represent HTML &lt;video&gt; tag.
		/// </summary>
		public HtmlVideoElement() : base("video") { }
	}
}

