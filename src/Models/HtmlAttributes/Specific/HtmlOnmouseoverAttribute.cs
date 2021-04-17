using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onmouseover")]
	public class HtmlOnmouseoverAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnmouseoverAttribute class represent HTML onmouseover attribute.
		/// </summary>
		public HtmlOnmouseoverAttribute(string value) : base("onmouseover", value)
		{
		}
	}
}
