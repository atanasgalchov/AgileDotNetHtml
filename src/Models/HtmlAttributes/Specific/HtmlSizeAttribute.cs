using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("size", new string[] { "input", "select" })]
	public class HtmlSizeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlSizeAttribute class represent HTML size attribute.
		/// </summary>
		public HtmlSizeAttribute(string value) : base("size", value)
		{
		}
	}
}
