using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onerror", new string[] { "audio", "body", "embed", "img", "object", "script", "style", "video" })]
	public class HtmlOnerrorAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnerrorAttribute class represent HTML onerror attribute.
		/// </summary>
		public HtmlOnerrorAttribute(string value) : base("onerror", value)
		{
		}
	}
}
