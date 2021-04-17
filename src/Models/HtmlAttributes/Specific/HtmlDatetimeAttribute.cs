using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("datetime", new string[] { "del", "ins", "time" })]
	public class HtmlDatetimeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlDatetimeAttribute class represent HTML datetime attribute.
		/// </summary>
		public HtmlDatetimeAttribute(string value) : base("datetime", value)
		{
		}
	}
}
