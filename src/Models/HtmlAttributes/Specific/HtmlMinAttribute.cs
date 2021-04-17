using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("min", new string[] { "input", "meter" })]
	public class HtmlMinAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlMinAttribute class represent HTML min attribute.
		/// </summary>
		public HtmlMinAttribute(string value) : base("min", value)
		{
		}
	}
}
