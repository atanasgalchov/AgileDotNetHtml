using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("max", new string[] { "input", "meter", "progress" })]
	public class HtmlMaxAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlMaxAttribute class represent HTML max attribute.
		/// </summary>
		public HtmlMaxAttribute(string value) : base("max", value)
		{
		}
	}
}
