using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("legend")]
	public class HtmlLegendElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlLegendElement class represent HTML &lt;legend&gt; tag.
		/// </summary>
		public HtmlLegendElement() : base("legend") { }
	}
}

