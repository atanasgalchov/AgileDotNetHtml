using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onwheel")]
	public class HtmlOnwheelAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnwheelAttribute class represent HTML onwheel attribute.
		/// </summary>
		public HtmlOnwheelAttribute(string value) : base("onwheel", value)
		{
		}
	}
}
