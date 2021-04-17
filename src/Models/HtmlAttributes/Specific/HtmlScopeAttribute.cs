using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("scope", new string[] { "th" })]
	public class HtmlScopeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlScopeAttribute class represent HTML scope attribute.
		/// </summary>
		public HtmlScopeAttribute(string value) : base("scope", value)
		{
		}
	}
}
