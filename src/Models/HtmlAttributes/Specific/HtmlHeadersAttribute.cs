using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("headers", new string[] { "td", "th" })]
	public class HtmlHeadersAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlHeadersAttribute class represent HTML headers attribute.
		/// </summary>
		public HtmlHeadersAttribute(string value) : base("headers", value)
		{
		}
	}
}
