using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("autocomplete", new string[] { "form", "input" })]
	public class HtmlAutocompleteAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlAutocompleteAttribute class represent HTML autocomplete attribute.
		/// </summary>
		public HtmlAutocompleteAttribute(string value) : base("autocomplete", value)
		{
		}
	}
}
