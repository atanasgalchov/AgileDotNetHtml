using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onpageshow", new string[] { "body" })]
	public class HtmlOnpageshowAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnpageshowAttribute class represent HTML onpageshow attribute.
		/// </summary>
		public HtmlOnpageshowAttribute(string value) : base("onpageshow", value)
		{
		}
	}
}
