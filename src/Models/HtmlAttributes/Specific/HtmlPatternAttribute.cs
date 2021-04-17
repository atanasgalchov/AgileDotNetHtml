using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("pattern", new string[] { "input" })]
	public class HtmlPatternAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlPatternAttribute class represent HTML pattern attribute.
		/// </summary>
		public HtmlPatternAttribute(string value) : base("pattern", value)
		{
		}
	}
}
