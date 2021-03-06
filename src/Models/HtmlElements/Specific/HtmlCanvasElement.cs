using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("canvas")]
	public class HtmlCanvasElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlCanvasElement class represent HTML &lt;canvas&gt; tag.
		/// </summary>
		public HtmlCanvasElement() : base("canvas") { }
	}
}

