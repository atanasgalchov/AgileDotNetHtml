using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("value", new string[] { "button", "input", "li", "option", "meter", "progress", "param" })]
	public class HtmlValueAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlValueAttribute class represent HTML value attribute.
		/// </summary>
		public HtmlValueAttribute(string value) : base("value", value)
		{
		}
	}
}
