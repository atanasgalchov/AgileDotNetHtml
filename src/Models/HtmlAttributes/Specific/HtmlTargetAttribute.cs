using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("target", new string[] { "a", "area", "base", "form" })]
	public class HtmlTargetAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlTargetAttribute class represent HTML target attribute.
		/// </summary>
		public HtmlTargetAttribute(string value) : base("target", value)
		{
		}
	}
}
