using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("name", new string[] { "button", "fieldset", "form", "iframe", "input", "map", "meta", "object", "output", "param", "select", "textarea" })]
	public class HtmlNameAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlNameAttribute class represent HTML name attribute.
		/// </summary>
		public HtmlNameAttribute(string value) : base("name", value)
		{
		}
	}
}
