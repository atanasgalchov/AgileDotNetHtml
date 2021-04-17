using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onended", new string[] { "audio", "video" })]
	public class HtmlOnendedAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnendedAttribute class represent HTML onended attribute.
		/// </summary>
		public HtmlOnendedAttribute(string value) : base("onended", value)
		{
		}
	}
}
