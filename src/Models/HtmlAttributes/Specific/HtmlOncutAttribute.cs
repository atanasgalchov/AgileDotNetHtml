using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("oncut")]
	public class HtmlOncutAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOncutAttribute class represent HTML oncut attribute.
		/// </summary>
		public HtmlOncutAttribute(string value) : base("oncut", value)
		{
		}
	}
}
