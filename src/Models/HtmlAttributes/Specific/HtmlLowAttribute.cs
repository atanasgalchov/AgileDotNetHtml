using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("low", new string[] { "meter" })]
	public class HtmlLowAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlLowAttribute class represent HTML low attribute.
		/// </summary>
		public HtmlLowAttribute(string value) : base("low", value)
		{
		}
	}
}
