using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("figure")]
	public class HtmlFigureElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlFigureElement class represent HTML &lt;figure&gt; tag.
		/// </summary>
		public HtmlFigureElement() : base("figure") { }
	}
}

