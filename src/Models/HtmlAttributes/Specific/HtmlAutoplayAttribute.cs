using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("autoplay", new string[] { "audio", "video" })]
	public class HtmlAutoplayAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlAutoplayAttribute class represent HTML autoplay attribute.
		/// </summary>
		public HtmlAutoplayAttribute(string value) : base("autoplay", value)
		{
		}
	}
}
