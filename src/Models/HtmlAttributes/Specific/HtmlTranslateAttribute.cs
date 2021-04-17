using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("translate")]
	public class HtmlTranslateAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlTranslateAttribute class represent HTML translate attribute.
		/// </summary>
		public HtmlTranslateAttribute(string value) : base("translate", value)
		{
		}
	}
}
