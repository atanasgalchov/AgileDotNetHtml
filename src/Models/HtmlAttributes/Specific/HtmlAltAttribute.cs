using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("alt", new string[] { "area", "img", "input" })]
	public class HtmlAltAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlAltAttribute class represent HTML alt attribute.
		/// </summary>
		public HtmlAltAttribute(string value) : base("alt", value)
		{
		}
	}
}
