using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("frame")]
	public class HtmlFrameElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlFrameElement class represent HTML &lt;frame&gt; tag.
		/// </summary>
		public HtmlFrameElement() : base("frame") { }
	}
}

