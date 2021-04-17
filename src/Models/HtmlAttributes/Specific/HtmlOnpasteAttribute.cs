using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onpaste")]
	public class HtmlOnpasteAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnpasteAttribute class represent HTML onpaste attribute.
		/// </summary>
		public HtmlOnpasteAttribute(string value) : base("onpaste", value)
		{
		}
	}
}
