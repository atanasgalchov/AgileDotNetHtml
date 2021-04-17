using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("colspan", new string[] { "td", "th" })]
	public class HtmlColspanAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlColspanAttribute class represent HTML colspan attribute.
		/// </summary>
		public HtmlColspanAttribute(string value) : base("colspan", value)
		{
		}
	}
}
