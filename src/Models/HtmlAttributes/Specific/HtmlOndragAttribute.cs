using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ondrag")]
	public class HtmlOndragAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOndragAttribute class represent HTML ondrag attribute.
		/// </summary>
		public HtmlOndragAttribute(string value) : base("ondrag", value)
		{
		}
	}
}
