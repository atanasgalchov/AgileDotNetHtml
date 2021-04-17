using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("formaction", new string[] { "button", "input" })]
	public class HtmlFormactionAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlFormactionAttribute class represent HTML formaction attribute.
		/// </summary>
		public HtmlFormactionAttribute(string value) : base("formaction", value)
		{
		}
	}
}
