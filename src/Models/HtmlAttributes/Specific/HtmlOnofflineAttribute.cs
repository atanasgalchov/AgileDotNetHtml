using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onoffline", new string[] { "body" })]
	public class HtmlOnofflineAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnofflineAttribute class represent HTML onoffline attribute.
		/// </summary>
		public HtmlOnofflineAttribute(string value) : base("onoffline", value)
		{
		}
	}
}
