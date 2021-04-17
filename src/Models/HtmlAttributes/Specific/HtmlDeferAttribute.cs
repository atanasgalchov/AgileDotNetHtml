using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("defer", new string[] { "script" })]
	public class HtmlDeferAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlDeferAttribute class represent HTML defer attribute.
		/// </summary>
		public HtmlDeferAttribute(string value) : base("defer", value)
		{
		}
	}
}
