using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onkeydown")]
	public class HtmlOnkeydownAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnkeydownAttribute class represent HTML onkeydown attribute.
		/// </summary>
		public HtmlOnkeydownAttribute(string value) : base("onkeydown", value)
		{
		}
	}
}
