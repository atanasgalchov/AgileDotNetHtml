using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ondragstart")]
	public class HtmlOndragstartAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOndragstartAttribute class represent HTML ondragstart attribute.
		/// </summary>
		public HtmlOndragstartAttribute(string value) : base("ondragstart", value)
		{
		}
	}
}
