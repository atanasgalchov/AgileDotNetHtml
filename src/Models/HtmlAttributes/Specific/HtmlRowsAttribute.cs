using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("rows", new string[] { "textarea" })]
	public class HtmlRowsAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlRowsAttribute class represent HTML rows attribute.
		/// </summary>
		public HtmlRowsAttribute(string value) : base("rows", value)
		{
		}
	}
}
