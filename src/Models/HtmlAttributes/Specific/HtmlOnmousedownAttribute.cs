using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onmousedown")]
	public class HtmlOnmousedownAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnmousedownAttribute class represent HTML onmousedown attribute.
		/// </summary>
		public HtmlOnmousedownAttribute(string value) : base("onmousedown", value)
		{
		}
	}
}
