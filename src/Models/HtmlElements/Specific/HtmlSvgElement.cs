using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("svg")]
	public class HtmlSvgElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlSvgElement class represent HTML &lt;svg&gt; tag.
		/// </summary>
		public HtmlSvgElement() : base("svg") { }
	}
}

