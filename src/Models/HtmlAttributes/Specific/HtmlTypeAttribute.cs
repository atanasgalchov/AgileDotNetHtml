using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("type", new string[] { "a", "button", "embed", "input", "link", "menu", "object", "script", "source", "style" })]
	public class HtmlTypeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlTypeAttribute class represent HTML type attribute.
		/// </summary>
		public HtmlTypeAttribute(string value) : base("type", value)
		{
		}
	}
}
