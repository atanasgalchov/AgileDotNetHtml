using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("accesskey")]
	public class HtmlAccesskeyAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlAccesskeyAttribute class represent HTML accesskey attribute.
		/// </summary>
		public HtmlAccesskeyAttribute(string value) : base("accesskey", value)
		{
		}
	}
}
