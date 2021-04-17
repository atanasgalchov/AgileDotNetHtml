using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onseeked", new string[] { "audio", "video" })]
	public class HtmlOnseekedAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnseekedAttribute class represent HTML onseeked attribute.
		/// </summary>
		public HtmlOnseekedAttribute(string value) : base("onseeked", value)
		{
		}
	}
}
