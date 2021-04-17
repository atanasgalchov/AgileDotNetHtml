using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("height", new string[] { "embed", "iframe", "img", "input", "object", "video" })]
	public class HtmlHeightAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlHeightAttribute class represent HTML height attribute.
		/// </summary>
		public HtmlHeightAttribute(string value) : base("height", value)
		{
		}
	}
}
