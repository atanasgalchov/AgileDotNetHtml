using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("usemap", new string[] { "img", "object" })]
	public class HtmlUsemapAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlUsemapAttribute class represent HTML usemap attribute.
		/// </summary>
		public HtmlUsemapAttribute(string value) : base("usemap", value)
		{
		}
	}
}
