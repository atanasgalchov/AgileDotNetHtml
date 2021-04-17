using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("accept", new string[] { "input" })]
	public class HtmlAcceptAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlAcceptAttribute class represent HTML accept attribute.
		/// </summary>
		public HtmlAcceptAttribute(string value) : base("accept", value)
		{
		}
	}
}
