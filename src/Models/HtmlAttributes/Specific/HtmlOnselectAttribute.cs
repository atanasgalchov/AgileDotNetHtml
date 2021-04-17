using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onselect")]
	public class HtmlOnselectAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnselectAttribute class represent HTML onselect attribute.
		/// </summary>
		public HtmlOnselectAttribute(string value) : base("onselect", value)
		{
		}
	}
}
