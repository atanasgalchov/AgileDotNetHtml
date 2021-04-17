using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("media", new string[] { "a", "area", "link", "source", "style" })]
	public class HtmlMediaAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlMediaAttribute class represent HTML media attribute.
		/// </summary>
		public HtmlMediaAttribute(string value) : base("media", value)
		{
		}
	}
}
