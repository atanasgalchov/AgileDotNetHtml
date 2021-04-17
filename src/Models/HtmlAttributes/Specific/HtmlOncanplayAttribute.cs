using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("oncanplay", new string[] { "audio", "embed", "object", "video" })]
	public class HtmlOncanplayAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOncanplayAttribute class represent HTML oncanplay attribute.
		/// </summary>
		public HtmlOncanplayAttribute(string value) : base("oncanplay", value)
		{
		}
	}
}
