using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("id")]
	public class HtmlIdAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlIdAttribute class represent HTML id attribute.
		/// </summary>
		public HtmlIdAttribute(string value) : base("id", value)
		{
		}
	}
}
