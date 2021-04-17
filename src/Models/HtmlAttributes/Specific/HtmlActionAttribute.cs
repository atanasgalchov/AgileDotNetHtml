using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("action", new string[] { "form" })]
	public class HtmlActionAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlActionAttribute class represent HTML action attribute.
		/// </summary>
		public HtmlActionAttribute(string value) : base("action", value)
		{
		}
	}
}
