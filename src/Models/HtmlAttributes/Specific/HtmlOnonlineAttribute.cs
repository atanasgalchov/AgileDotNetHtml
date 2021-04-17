using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ononline", new string[] { "body" })]
	public class HtmlOnonlineAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnonlineAttribute class represent HTML ononline attribute.
		/// </summary>
		public HtmlOnonlineAttribute(string value) : base("ononline", value)
		{
		}
	}
}
