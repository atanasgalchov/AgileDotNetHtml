using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("kind", new string[] { "track" })]
	public class HtmlKindAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlKindAttribute class represent HTML kind attribute.
		/// </summary>
		public HtmlKindAttribute(string value) : base("kind", value)
		{
		}
	}
}
