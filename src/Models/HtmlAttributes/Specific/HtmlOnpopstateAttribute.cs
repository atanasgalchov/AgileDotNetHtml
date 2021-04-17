using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onpopstate", new string[] { "body" })]
	public class HtmlOnpopstateAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnpopstateAttribute class represent HTML onpopstate attribute.
		/// </summary>
		public HtmlOnpopstateAttribute(string value) : base("onpopstate", value)
		{
		}
	}
}
