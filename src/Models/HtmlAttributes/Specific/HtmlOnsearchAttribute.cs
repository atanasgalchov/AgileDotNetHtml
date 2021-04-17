using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onsearch", new string[] { "input" })]
	public class HtmlOnsearchAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnsearchAttribute class represent HTML onsearch attribute.
		/// </summary>
		public HtmlOnsearchAttribute(string value) : base("onsearch", value)
		{
		}
	}
}
