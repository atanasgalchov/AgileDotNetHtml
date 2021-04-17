using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onfocus")]
	public class HtmlOnfocusAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnfocusAttribute class represent HTML onfocus attribute.
		/// </summary>
		public HtmlOnfocusAttribute(string value) : base("onfocus", value)
		{
		}
	}
}
