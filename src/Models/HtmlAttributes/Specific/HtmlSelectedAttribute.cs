using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("selected", new string[] { "option" })]
	public class HtmlSelectedAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlSelectedAttribute class represent HTML selected attribute.
		/// </summary>
		public HtmlSelectedAttribute(string value) : base("selected", value)
		{
		}
	}
}
