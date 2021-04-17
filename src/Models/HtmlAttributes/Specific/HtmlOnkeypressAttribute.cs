using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onkeypress")]
	public class HtmlOnkeypressAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnkeypressAttribute class represent HTML onkeypress attribute.
		/// </summary>
		public HtmlOnkeypressAttribute(string value) : base("onkeypress", value)
		{
		}
	}
}
