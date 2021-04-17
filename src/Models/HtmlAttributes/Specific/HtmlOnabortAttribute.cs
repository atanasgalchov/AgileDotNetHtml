using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onabort", new string[] { "audio", "embed", "img", "object", "video" })]
	public class HtmlOnabortAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnabortAttribute class represent HTML onabort attribute.
		/// </summary>
		public HtmlOnabortAttribute(string value) : base("onabort", value)
		{
		}
	}
}
