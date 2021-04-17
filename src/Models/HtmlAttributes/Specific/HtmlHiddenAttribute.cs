using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("hidden")]
	public class HtmlHiddenAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlHiddenAttribute class represent HTML hidden attribute.
		/// </summary>
		public HtmlHiddenAttribute(string value) : base("hidden", value)
		{
		}
	}
}
