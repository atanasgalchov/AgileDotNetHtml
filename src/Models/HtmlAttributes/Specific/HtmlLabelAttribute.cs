using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("label", new string[] { "track", "option", "optgroup" })]
	public class HtmlLabelAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlLabelAttribute class represent HTML label attribute.
		/// </summary>
		public HtmlLabelAttribute(string value) : base("label", value)
		{
		}
	}
}
