using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onreset", new string[] { "form" })]
	public class HtmlOnresetAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnresetAttribute class represent HTML onreset attribute.
		/// </summary>
		public HtmlOnresetAttribute(string value) : base("onreset", value)
		{
		}
	}
}
