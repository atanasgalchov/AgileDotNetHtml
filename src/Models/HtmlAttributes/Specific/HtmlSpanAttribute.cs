using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("span", new string[] { "col", "colgroup" })]
	public class HtmlSpanAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlSpanAttribute class represent HTML span attribute.
		/// </summary>
		public HtmlSpanAttribute(string value) : base("span", value)
		{
		}
	}
}
