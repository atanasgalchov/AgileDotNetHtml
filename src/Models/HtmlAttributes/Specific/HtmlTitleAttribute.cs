using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("title")]
	public class HtmlTitleAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlTitleAttribute class represent HTML title attribute.
		/// </summary>
		public HtmlTitleAttribute(string value) : base("title", value)
		{
		}
	}
}
