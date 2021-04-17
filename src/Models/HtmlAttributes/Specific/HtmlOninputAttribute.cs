using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("oninput")]
	public class HtmlOninputAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOninputAttribute class represent HTML oninput attribute.
		/// </summary>
		public HtmlOninputAttribute(string value) : base("oninput", value)
		{
		}
	}
}
