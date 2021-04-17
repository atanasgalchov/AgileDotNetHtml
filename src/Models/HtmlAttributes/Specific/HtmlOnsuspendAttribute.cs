using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onsuspend", new string[] { "audio", "video" })]
	public class HtmlOnsuspendAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnsuspendAttribute class represent HTML onsuspend attribute.
		/// </summary>
		public HtmlOnsuspendAttribute(string value) : base("onsuspend", value)
		{
		}
	}
}
