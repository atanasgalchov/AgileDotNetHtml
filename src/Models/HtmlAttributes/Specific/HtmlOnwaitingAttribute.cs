using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onwaiting", new string[] { "audio", "video" })]
	public class HtmlOnwaitingAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnwaitingAttribute class represent HTML onwaiting attribute.
		/// </summary>
		public HtmlOnwaitingAttribute(string value) : base("onwaiting", value)
		{
		}
	}
}
