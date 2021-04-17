using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("autofocus", new string[] { "button", "input", "select", "textarea" })]
	public class HtmlAutofocusAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlAutofocusAttribute class represent HTML autofocus attribute.
		/// </summary>
		public HtmlAutofocusAttribute(string value) : base("autofocus", value)
		{
		}
	}
}
