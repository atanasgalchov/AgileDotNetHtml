using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("accept-charset", new string[] { "form" })]
	public class HtmlAcceptCharsetAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlAccept-charsetAttribute class represent HTML accept-charset attribute.
		/// </summary>
		public HtmlAcceptCharsetAttribute(string value) : base("accept-charset", value)
		{
		}
	}
}
