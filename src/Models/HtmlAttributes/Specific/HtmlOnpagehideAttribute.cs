using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onpagehide", new string[] { "body" })]
	public class HtmlOnpagehideAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnpagehideAttribute class represent HTML onpagehide attribute.
		/// </summary>
		public HtmlOnpagehideAttribute(string value) : base("onpagehide", value)
		{
		}
	}
}
