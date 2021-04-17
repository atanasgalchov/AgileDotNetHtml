using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ondurationchange", new string[] { "audio", "video" })]
	public class HtmlOndurationchangeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOndurationchangeAttribute class represent HTML ondurationchange attribute.
		/// </summary>
		public HtmlOndurationchangeAttribute(string value) : base("ondurationchange", value)
		{
		}
	}
}
