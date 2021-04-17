using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onplay", new string[] { "audio", "video" })]
	public class HtmlOnplayAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnplayAttribute class represent HTML onplay attribute.
		/// </summary>
		public HtmlOnplayAttribute(string value) : base("onplay", value)
		{
		}
	}
}
