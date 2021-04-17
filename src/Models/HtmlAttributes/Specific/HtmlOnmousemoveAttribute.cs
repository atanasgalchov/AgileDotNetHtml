using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onmousemove")]
	public class HtmlOnmousemoveAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnmousemoveAttribute class represent HTML onmousemove attribute.
		/// </summary>
		public HtmlOnmousemoveAttribute(string value) : base("onmousemove", value)
		{
		}
	}
}
