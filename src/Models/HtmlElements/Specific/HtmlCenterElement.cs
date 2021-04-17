using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("center")]
	public class HtmlCenterElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlCenterElement class represent HTML &lt;center&gt; tag.
		/// </summary>
		public HtmlCenterElement() : base("center") { }
	}
}

