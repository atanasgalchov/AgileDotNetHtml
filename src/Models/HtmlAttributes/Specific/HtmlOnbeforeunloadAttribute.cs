using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onbeforeunload", new string[] { "body" })]
	public class HtmlOnbeforeunloadAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnbeforeunloadAttribute class represent HTML onbeforeunload attribute.
		/// </summary>
		public HtmlOnbeforeunloadAttribute(string value) : base("onbeforeunload", value)
		{
		}
	}
}
