using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("multiple", new string[] { "input", "select" })]
	public class HtmlMultipleAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlMultipleAttribute class represent HTML multiple attribute.
		/// </summary>
		public HtmlMultipleAttribute(string value) : base("multiple", value)
		{
		}
	}
}
