using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onmouseout")]
	public class HtmlOnmouseoutAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnmouseoutAttribute class represent HTML onmouseout attribute.
		/// </summary>
		public HtmlOnmouseoutAttribute(string value) : base("onmouseout", value)
		{
		}
	}
}
