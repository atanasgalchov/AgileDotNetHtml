using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ondblclick")]
	public class HtmlOndblclickAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOndblclickAttribute class represent HTML ondblclick attribute.
		/// </summary>
		public HtmlOndblclickAttribute(string value) : base("ondblclick", value)
		{
		}
	}
}
