using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("oninvalid")]
	public class HtmlOninvalidAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOninvalidAttribute class represent HTML oninvalid attribute.
		/// </summary>
		public HtmlOninvalidAttribute(string value) : base("oninvalid", value)
		{
		}
	}
}
