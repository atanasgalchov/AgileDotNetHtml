using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("disabled", new string[] { "button", "fieldset", "input", "option", "select", "textarea" })]
	public class HtmlDisabledAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlDisabledAttribute class represent HTML disabled attribute.
		/// </summary>
		public HtmlDisabledAttribute(string value) : base("disabled", value)
		{
		}
	}
}
