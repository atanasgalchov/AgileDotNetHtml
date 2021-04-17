using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("contenteditable")]
	public class HtmlContenteditableAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlContenteditableAttribute class represent HTML contenteditable attribute.
		/// </summary>
		public HtmlContenteditableAttribute(string value) : base("contenteditable", value)
		{
		}
	}
}
