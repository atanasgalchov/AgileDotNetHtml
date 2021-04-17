using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("content", new string[] { "meta" })]
	public class HtmlContentAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlContentAttribute class represent HTML content attribute.
		/// </summary>
		public HtmlContentAttribute(string value) : base("content", value)
		{
		}
	}
}
