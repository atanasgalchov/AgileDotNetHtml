using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("span")]
	public class HtmlSpanElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlSpanElement class represent HTML &lt;span&gt; tag.
		/// </summary>
		public HtmlSpanElement() : base("span") { }
	}
}

