using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onsubmit", new string[] { "form" })]
	public class HtmlOnsubmitAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnsubmitAttribute class represent HTML onsubmit attribute.
		/// </summary>
		public HtmlOnsubmitAttribute(string value) : base("onsubmit", value)
		{
		}
	}
}
