using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ismap", new string[] { "img" })]
	public class HtmlIsmapAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlIsmapAttribute class represent HTML ismap attribute.
		/// </summary>
		public HtmlIsmapAttribute(string value) : base("ismap", value)
		{
		}
	}
}
