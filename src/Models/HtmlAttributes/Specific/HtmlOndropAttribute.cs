using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ondrop")]
	public class HtmlOndropAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOndropAttribute class represent HTML ondrop attribute.
		/// </summary>
		public HtmlOndropAttribute(string value) : base("ondrop", value)
		{
		}
	}
}
