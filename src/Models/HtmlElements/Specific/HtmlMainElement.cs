using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("main")]
	public class HtmlMainElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlMainElement class represent HTML &lt;main&gt; tag.
		/// </summary>
		public HtmlMainElement() : base("main") { }
	}
}

