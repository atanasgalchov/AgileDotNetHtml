using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onloadedmetadata", new string[] { "audio", "video" })]
	public class HtmlOnloadedmetadataAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnloadedmetadataAttribute class represent HTML onloadedmetadata attribute.
		/// </summary>
		public HtmlOnloadedmetadataAttribute(string value) : base("onloadedmetadata", value)
		{
		}
	}
}
