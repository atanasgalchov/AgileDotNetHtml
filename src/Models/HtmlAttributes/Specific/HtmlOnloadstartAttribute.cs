using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onloadstart", new string[] { "audio", "video" })]
	public class HtmlOnloadstartAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnloadstartAttribute class represent HTML onloadstart attribute.
		/// </summary>
		public HtmlOnloadstartAttribute(string value) : base("onloadstart", value)
		{
		}
	}
}
