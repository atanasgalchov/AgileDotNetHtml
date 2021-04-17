using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("wrap", new string[] { "textarea" })]
	public class HtmlWrapAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlWrapAttribute class represent HTML wrap attribute.
		/// </summary>
		public HtmlWrapAttribute(string value) : base("wrap", value)
		{
		}
	}
}
