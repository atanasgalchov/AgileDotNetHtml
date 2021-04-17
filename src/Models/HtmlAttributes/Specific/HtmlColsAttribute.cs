using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("cols", new string[] { "textarea" })]
	public class HtmlColsAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlColsAttribute class represent HTML cols attribute.
		/// </summary>
		public HtmlColsAttribute(string value) : base("cols", value)
		{
		}
	}
}
