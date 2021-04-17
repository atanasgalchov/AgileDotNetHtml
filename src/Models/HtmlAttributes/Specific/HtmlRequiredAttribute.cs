using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("required", new string[] { "input", "select", "textarea" })]
	public class HtmlRequiredAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlRequiredAttribute class represent HTML required attribute.
		/// </summary>
		public HtmlRequiredAttribute(string value) : base("required", value)
		{
		}
	}
}
