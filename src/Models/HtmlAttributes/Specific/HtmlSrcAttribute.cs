using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("src", new string[] { "audio", "embed", "iframe", "img", "input", "script", "source", "track", "video" })]
	public class HtmlSrcAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlSrcAttribute class represent HTML src attribute.
		/// </summary>
		public HtmlSrcAttribute(string value) : base("src", value)
		{
		}
	}
}
