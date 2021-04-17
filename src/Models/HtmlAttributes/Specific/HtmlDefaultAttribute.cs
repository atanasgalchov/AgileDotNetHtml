using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("default", new string[] { "track" })]
	public class HtmlDefaultAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlDefaultAttribute class represent HTML default attribute.
		/// </summary>
		public HtmlDefaultAttribute(string value) : base("default", value)
		{
		}
	}
}
