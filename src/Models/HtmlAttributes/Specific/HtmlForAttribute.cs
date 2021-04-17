using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("for", new string[] { "output", "label" })]
	public class HtmlForAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlForAttribute class represent HTML for attribute.
		/// </summary>
		public HtmlForAttribute(string value) : base("for", value)
		{
		}
	}
}
