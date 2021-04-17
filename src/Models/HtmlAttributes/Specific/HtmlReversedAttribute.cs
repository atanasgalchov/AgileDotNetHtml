using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("reversed", new string[] { "ol" })]
	public class HtmlReversedAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlReversedAttribute class represent HTML reversed attribute.
		/// </summary>
		public HtmlReversedAttribute(string value) : base("reversed", value)
		{
		}
	}
}
