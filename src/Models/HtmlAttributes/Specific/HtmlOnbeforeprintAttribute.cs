using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onbeforeprint", new string[] { "body" })]
	public class HtmlOnbeforeprintAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnbeforeprintAttribute class represent HTML onbeforeprint attribute.
		/// </summary>
		public HtmlOnbeforeprintAttribute(string value) : base("onbeforeprint", value)
		{
		}
	}
}
