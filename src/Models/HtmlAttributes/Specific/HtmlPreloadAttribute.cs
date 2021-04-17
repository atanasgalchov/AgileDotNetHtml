using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("preload", new string[] { "audio", "video" })]
	public class HtmlPreloadAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlPreloadAttribute class represent HTML preload attribute.
		/// </summary>
		public HtmlPreloadAttribute(string value) : base("preload", value)
		{
		}
	}
}
