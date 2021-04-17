using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("class")]
	public class HtmlClassAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlClassAttribute class represent HTML class attribute.
		/// </summary>
		public HtmlClassAttribute(string value) : base("class", value)
		{
		}
	}
}
