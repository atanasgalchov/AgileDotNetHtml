using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("method", new string[] { "form" })]
	public class HtmlMethodAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlMethodAttribute class represent HTML method attribute.
		/// </summary>
		public HtmlMethodAttribute(string value) : base("method", value)
		{
		}
	}
}
