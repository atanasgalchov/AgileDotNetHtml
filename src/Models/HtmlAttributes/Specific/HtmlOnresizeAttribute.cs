using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onresize", new string[] { "body" })]
	public class HtmlOnresizeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnresizeAttribute class represent HTML onresize attribute.
		/// </summary>
		public HtmlOnresizeAttribute(string value) : base("onresize", value)
		{
		}
	}
}
