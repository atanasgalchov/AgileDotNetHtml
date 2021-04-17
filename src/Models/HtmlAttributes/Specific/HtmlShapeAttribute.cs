using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("shape", new string[] { "area" })]
	public class HtmlShapeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlShapeAttribute class represent HTML shape attribute.
		/// </summary>
		public HtmlShapeAttribute(string value) : base("shape", value)
		{
		}
	}
}
