using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onprogress", new string[] { "audio", "video" })]
	public class HtmlOnprogressAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnprogressAttribute class represent HTML onprogress attribute.
		/// </summary>
		public HtmlOnprogressAttribute(string value) : base("onprogress", value)
		{
		}
	}
}
