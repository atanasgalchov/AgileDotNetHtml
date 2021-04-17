using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onseeking", new string[] { "audio", "video" })]
	public class HtmlOnseekingAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnseekingAttribute class represent HTML onseeking attribute.
		/// </summary>
		public HtmlOnseekingAttribute(string value) : base("onseeking", value)
		{
		}
	}
}
