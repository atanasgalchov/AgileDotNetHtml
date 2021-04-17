using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("novalidate", new string[] { "form" })]
	public class HtmlNovalidateAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlNovalidateAttribute class represent HTML novalidate attribute.
		/// </summary>
		public HtmlNovalidateAttribute(string value) : base("novalidate", value)
		{
		}
	}
}
