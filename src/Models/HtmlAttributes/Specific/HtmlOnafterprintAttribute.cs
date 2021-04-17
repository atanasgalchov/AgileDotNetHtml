using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onafterprint", new string[] { "body" })]
	public class HtmlOnafterprintAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnafterprintAttribute class represent HTML onafterprint attribute.
		/// </summary>
		public HtmlOnafterprintAttribute(string value) : base("onafterprint", value)
		{
		}
	}
}
