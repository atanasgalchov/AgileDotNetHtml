using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("href", new string[] { "a", "area", "base", "link" })]
	public class HtmlHrefAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlHrefAttribute class represent HTML href attribute.
		/// </summary>
		public HtmlHrefAttribute(string value) : base("href", value)
		{
		}
	}
}
