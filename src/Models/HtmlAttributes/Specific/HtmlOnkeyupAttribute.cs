using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onkeyup")]
	public class HtmlOnkeyupAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnkeyupAttribute class represent HTML onkeyup attribute.
		/// </summary>
		public HtmlOnkeyupAttribute(string value) : base("onkeyup", value)
		{
		}
	}
}
