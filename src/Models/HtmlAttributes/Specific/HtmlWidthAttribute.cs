using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("width", new string[] { "embed", "iframe", "img", "input", "object", "video" })]
	public class HtmlWidthAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlWidthAttribute class represent HTML width attribute.
		/// </summary>
		public HtmlWidthAttribute(string value) : base("width", value)
		{
		}
	}
}
