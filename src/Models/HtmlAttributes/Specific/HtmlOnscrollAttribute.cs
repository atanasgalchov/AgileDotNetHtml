using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onscroll")]
	public class HtmlOnscrollAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnscrollAttribute class represent HTML onscroll attribute.
		/// </summary>
		public HtmlOnscrollAttribute(string value) : base("onscroll", value)
		{
		}
	}
}
