using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ondragend")]
	public class HtmlOndragendAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOndragendAttribute class represent HTML ondragend attribute.
		/// </summary>
		public HtmlOndragendAttribute(string value) : base("ondragend", value)
		{
		}
	}
}
