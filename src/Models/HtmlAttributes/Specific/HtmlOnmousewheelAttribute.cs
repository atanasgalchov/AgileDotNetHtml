using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onmousewheel")]
	public class HtmlOnmousewheelAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnmousewheelAttribute class represent HTML onmousewheel attribute.
		/// </summary>
		public HtmlOnmousewheelAttribute(string value) : base("onmousewheel", value)
		{
		}
	}
}
