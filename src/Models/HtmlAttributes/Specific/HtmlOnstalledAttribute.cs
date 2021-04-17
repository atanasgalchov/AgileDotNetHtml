using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onstalled", new string[] { "audio", "video" })]
	public class HtmlOnstalledAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnstalledAttribute class represent HTML onstalled attribute.
		/// </summary>
		public HtmlOnstalledAttribute(string value) : base("onstalled", value)
		{
		}
	}
}
