using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("list", new string[] { "input" })]
	public class HtmlListAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlListAttribute class represent HTML list attribute.
		/// </summary>
		public HtmlListAttribute(string value) : base("list", value)
		{
		}
	}
}
