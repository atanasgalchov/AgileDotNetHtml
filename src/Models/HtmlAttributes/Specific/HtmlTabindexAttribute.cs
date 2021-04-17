using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("tabindex")]
	public class HtmlTabindexAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlTabindexAttribute class represent HTML tabindex attribute.
		/// </summary>
		public HtmlTabindexAttribute(string value) : base("tabindex", value)
		{
		}
	}
}
