using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onchange")]
	public class HtmlOnchangeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnchangeAttribute class represent HTML onchange attribute.
		/// </summary>
		public HtmlOnchangeAttribute(string value) : base("onchange", value)
		{
		}
	}
}
