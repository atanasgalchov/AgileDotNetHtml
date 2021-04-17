using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onload", new string[] { "body", "iframe", "img", "input", "link", "script", "style" })]
	public class HtmlOnloadAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnloadAttribute class represent HTML onload attribute.
		/// </summary>
		public HtmlOnloadAttribute(string value) : base("onload", value)
		{
		}
	}
}
