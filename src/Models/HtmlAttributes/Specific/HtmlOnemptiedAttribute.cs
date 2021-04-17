using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onemptied", new string[] { "audio", "video" })]
	public class HtmlOnemptiedAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnemptiedAttribute class represent HTML onemptied attribute.
		/// </summary>
		public HtmlOnemptiedAttribute(string value) : base("onemptied", value)
		{
		}
	}
}
