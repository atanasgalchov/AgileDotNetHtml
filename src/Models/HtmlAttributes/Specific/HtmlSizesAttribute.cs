using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("sizes", new string[] { "img", "link", "source" })]
	public class HtmlSizesAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlSizesAttribute class represent HTML sizes attribute.
		/// </summary>
		public HtmlSizesAttribute(string value) : base("sizes", value)
		{
		}
	}
}
