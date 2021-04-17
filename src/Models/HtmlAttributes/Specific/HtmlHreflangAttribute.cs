using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("hreflang", new string[] { "a", "area", "link" })]
	public class HtmlHreflangAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlHreflangAttribute class represent HTML hreflang attribute.
		/// </summary>
		public HtmlHreflangAttribute(string value) : base("hreflang", value)
		{
		}
	}
}
