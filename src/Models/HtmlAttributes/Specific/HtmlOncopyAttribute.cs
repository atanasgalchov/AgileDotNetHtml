using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("oncopy")]
	public class HtmlOncopyAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOncopyAttribute class represent HTML oncopy attribute.
		/// </summary>
		public HtmlOncopyAttribute(string value) : base("oncopy", value)
		{
		}
	}
}
