using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("srclang", new string[] { "track" })]
	public class HtmlSrclangAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlSrclangAttribute class represent HTML srclang attribute.
		/// </summary>
		public HtmlSrclangAttribute(string value) : base("srclang", value)
		{
		}
	}
}
