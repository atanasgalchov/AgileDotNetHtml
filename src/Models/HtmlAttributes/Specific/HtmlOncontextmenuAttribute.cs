using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("oncontextmenu")]
	public class HtmlOncontextmenuAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOncontextmenuAttribute class represent HTML oncontextmenu attribute.
		/// </summary>
		public HtmlOncontextmenuAttribute(string value) : base("oncontextmenu", value)
		{
		}
	}
}
