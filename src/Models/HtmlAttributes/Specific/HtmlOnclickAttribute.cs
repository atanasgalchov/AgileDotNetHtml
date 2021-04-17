using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onclick")]
	public class HtmlOnclickAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnclickAttribute class represent HTML onclick attribute.
		/// </summary>
		public HtmlOnclickAttribute(string value) : base("onclick", value)
		{
		}
	}
}
