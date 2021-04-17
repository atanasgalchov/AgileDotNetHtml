using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("ol")]
	public class HtmlOlElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlOlElement class represent HTML &lt;ol&gt; tag.
		/// </summary>
		public HtmlOlElement() : base("ol") { }
	}
}

