using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ontoggle", new string[] { "details" })]
	public class HtmlOntoggleAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOntoggleAttribute class represent HTML ontoggle attribute.
		/// </summary>
		public HtmlOntoggleAttribute(string value) : base("ontoggle", value)
		{
		}
	}
}
