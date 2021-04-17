using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("high", new string[] { "meter" })]
	public class HtmlHighAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlHighAttribute class represent HTML high attribute.
		/// </summary>
		public HtmlHighAttribute(string value) : base("high", value)
		{
		}
	}
}
