using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ondragleave")]
	public class HtmlOndragleaveAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOndragleaveAttribute class represent HTML ondragleave attribute.
		/// </summary>
		public HtmlOndragleaveAttribute(string value) : base("ondragleave", value)
		{
		}
	}
}
