using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("controls", new string[] { "audio", "video" })]
	public class HtmlControlsAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlControlsAttribute class represent HTML controls attribute.
		/// </summary>
		public HtmlControlsAttribute(string value) : base("controls", value)
		{
		}
	}
}
