using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("dirname", new string[] { "input", "textarea" })]
	public class HtmlDirnameAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlDirnameAttribute class represent HTML dirname attribute.
		/// </summary>
		public HtmlDirnameAttribute(string value) : base("dirname", value)
		{
		}
	}
}
