using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("form", new string[] { "button", "fieldset", "input", "meter", "object", "output", "select", "textarea" })]
	public class HtmlFormAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlFormAttribute class represent HTML form attribute.
		/// </summary>
		public HtmlFormAttribute(string value) : base("form", value)
		{
		}
	}
}
