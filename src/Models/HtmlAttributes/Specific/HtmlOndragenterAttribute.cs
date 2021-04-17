using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ondragenter")]
	public class HtmlOndragenterAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOndragenterAttribute class represent HTML ondragenter attribute.
		/// </summary>
		public HtmlOndragenterAttribute(string value) : base("ondragenter", value)
		{
		}
	}
}
