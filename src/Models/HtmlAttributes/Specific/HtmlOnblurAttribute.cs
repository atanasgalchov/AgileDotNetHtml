using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onblur")]
	public class HtmlOnblurAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnblurAttribute class represent HTML onblur attribute.
		/// </summary>
		public HtmlOnblurAttribute(string value) : base("onblur", value)
		{
		}
	}
}
