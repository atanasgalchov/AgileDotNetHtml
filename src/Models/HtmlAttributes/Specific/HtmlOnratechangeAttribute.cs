using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onratechange", new string[] { "audio", "video" })]
	public class HtmlOnratechangeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnratechangeAttribute class represent HTML onratechange attribute.
		/// </summary>
		public HtmlOnratechangeAttribute(string value) : base("onratechange", value)
		{
		}
	}
}
