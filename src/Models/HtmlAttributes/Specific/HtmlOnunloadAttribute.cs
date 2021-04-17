using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onunload", new string[] { "body" })]
	public class HtmlOnunloadAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnunloadAttribute class represent HTML onunload attribute.
		/// </summary>
		public HtmlOnunloadAttribute(string value) : base("onunload", value)
		{
		}
	}
}
