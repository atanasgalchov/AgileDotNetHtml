using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("start", new string[] { "ol" })]
	public class HtmlStartAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlStartAttribute class represent HTML start attribute.
		/// </summary>
		public HtmlStartAttribute(string value) : base("start", value)
		{
		}
	}
}
