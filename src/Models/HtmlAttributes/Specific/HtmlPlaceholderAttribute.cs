using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("placeholder", new string[] { "input", "textarea" })]
	public class HtmlPlaceholderAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlPlaceholderAttribute class represent HTML placeholder attribute.
		/// </summary>
		public HtmlPlaceholderAttribute(string value) : base("placeholder", value)
		{
		}
	}
}
