using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("lang")]
	public class HtmlLangAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlLangAttribute class represent HTML lang attribute.
		/// </summary>
		public HtmlLangAttribute(string value) : base("lang", value)
		{
		}
	}
}
