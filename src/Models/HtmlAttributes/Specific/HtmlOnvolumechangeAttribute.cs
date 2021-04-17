using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onvolumechange", new string[] { "audio", "video" })]
	public class HtmlOnvolumechangeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnvolumechangeAttribute class represent HTML onvolumechange attribute.
		/// </summary>
		public HtmlOnvolumechangeAttribute(string value) : base("onvolumechange", value)
		{
		}
	}
}
