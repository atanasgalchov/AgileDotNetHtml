using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("rowspan", new string[] { "td", "th" })]
	public class HtmlRowspanAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlRowspanAttribute class represent HTML rowspan attribute.
		/// </summary>
		public HtmlRowspanAttribute(string value) : base("rowspan", value)
		{
		}
	}
}
