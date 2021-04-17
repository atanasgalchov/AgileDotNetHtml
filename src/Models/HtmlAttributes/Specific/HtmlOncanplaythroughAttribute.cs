using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("oncanplaythrough", new string[] { "audio", "video" })]
	public class HtmlOncanplaythroughAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOncanplaythroughAttribute class represent HTML oncanplaythrough attribute.
		/// </summary>
		public HtmlOncanplaythroughAttribute(string value) : base("oncanplaythrough", value)
		{
		}
	}
}
