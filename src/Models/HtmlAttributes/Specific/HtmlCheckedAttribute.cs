using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("checked", new string[] { "input" })]
	public class HtmlCheckedAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlCheckedAttribute class represent HTML checked attribute.
		/// </summary>
		public HtmlCheckedAttribute(string value) : base("checked", value)
		{
		}
	}
}
