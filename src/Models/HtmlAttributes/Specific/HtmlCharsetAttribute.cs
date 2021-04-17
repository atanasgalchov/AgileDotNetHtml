using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("charset", new string[] { "meta", "script" })]
	public class HtmlCharsetAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlCharsetAttribute class represent HTML charset attribute.
		/// </summary>
		public HtmlCharsetAttribute(string value) : base("charset", value)
		{
		}
	}
}
