using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("optimum", new string[] { "meter" })]
	public class HtmlOptimumAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOptimumAttribute class represent HTML optimum attribute.
		/// </summary>
		public HtmlOptimumAttribute(string value) : base("optimum", value)
		{
		}
	}
}
