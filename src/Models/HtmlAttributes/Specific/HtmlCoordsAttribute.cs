using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("coords", new string[] { "area" })]
	public class HtmlCoordsAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlCoordsAttribute class represent HTML coords attribute.
		/// </summary>
		public HtmlCoordsAttribute(string value) : base("coords", value)
		{
		}
	}
}
