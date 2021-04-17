using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("style")]
	public class HtmlStyleAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlStyleAttribute class represent HTML style attribute.
		/// </summary>
		public HtmlStyleAttribute(string value) : base("style", value)
		{
		}
	}
}
