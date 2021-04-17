using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("label")]
	public class HtmlLabelElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlLabelElement class represent HTML &lt;label&gt; tag.
		/// </summary>
		public HtmlLabelElement() : base("label") { }
	}
}

