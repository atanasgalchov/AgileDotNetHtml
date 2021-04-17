using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("loop", new string[] { "audio", "video" })]
	public class HtmlLoopAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlLoopAttribute class represent HTML loop attribute.
		/// </summary>
		public HtmlLoopAttribute(string value) : base("loop", value)
		{
		}
	}
}
