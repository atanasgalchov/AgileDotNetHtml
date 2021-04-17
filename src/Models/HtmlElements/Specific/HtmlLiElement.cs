using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("li")]
	public class HtmlLiElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlLiElement class represent HTML &lt;li&gt; tag.
		/// </summary>
		public HtmlLiElement() : base("li") { }
	}
}

