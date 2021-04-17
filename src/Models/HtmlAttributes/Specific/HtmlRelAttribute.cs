using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("rel", new string[] { "a", "area", "form", "link" })]
	public class HtmlRelAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlRelAttribute class represent HTML rel attribute.
		/// </summary>
		public HtmlRelAttribute(string value) : base("rel", value)
		{
		}
	}
}
