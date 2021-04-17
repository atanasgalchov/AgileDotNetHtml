using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("data", new string[] { "object" })]
	public class HtmlDataAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlDataAttribute class represent HTML data attribute.
		/// </summary>
		public HtmlDataAttribute(string value) : base("data", value)
		{
		}
	}
}
