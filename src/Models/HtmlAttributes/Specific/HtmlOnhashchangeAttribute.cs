using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onhashchange", new string[] { "body" })]
	public class HtmlOnhashchangeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnhashchangeAttribute class represent HTML onhashchange attribute.
		/// </summary>
		public HtmlOnhashchangeAttribute(string value) : base("onhashchange", value)
		{
		}
	}
}
