using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("maxlength", new string[] { "input", "textarea" })]
	public class HtmlMaxlengthAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlMaxlengthAttribute class represent HTML maxlength attribute.
		/// </summary>
		public HtmlMaxlengthAttribute(string value) : base("maxlength", value)
		{
		}
	}
}
