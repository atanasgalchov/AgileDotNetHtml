using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("track")]
	public class HtmlTrackElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlTrackElement class represent HTML &lt;track&gt; tag.
		/// </summary>
		public HtmlTrackElement() : base("track") { }
	}
}

