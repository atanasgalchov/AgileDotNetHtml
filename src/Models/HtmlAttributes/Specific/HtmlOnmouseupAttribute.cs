using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onmouseup")]
	public class HtmlOnmouseupAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnmouseupAttribute class represent HTML onmouseup attribute.
		/// </summary>
		public HtmlOnmouseupAttribute(string value) : base("onmouseup", value)
		{
		}
	}
}
