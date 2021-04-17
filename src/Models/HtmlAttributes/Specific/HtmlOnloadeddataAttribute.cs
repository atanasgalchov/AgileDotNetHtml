using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onloadeddata", new string[] { "audio", "video" })]
	public class HtmlOnloadeddataAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnloadeddataAttribute class represent HTML onloadeddata attribute.
		/// </summary>
		public HtmlOnloadeddataAttribute(string value) : base("onloadeddata", value)
		{
		}
	}
}
