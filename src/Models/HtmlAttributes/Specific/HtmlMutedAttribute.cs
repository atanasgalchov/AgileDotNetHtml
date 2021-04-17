using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("muted", new string[] { "video", "audio" })]
	public class HtmlMutedAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlMutedAttribute class represent HTML muted attribute.
		/// </summary>
		public HtmlMutedAttribute(string value) : base("muted", value)
		{
		}
	}
}
