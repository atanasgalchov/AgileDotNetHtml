using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("readonly", new string[] { "input", "textarea" })]
	public class HtmlReadonlyAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlReadonlyAttribute class represent HTML readonly attribute.
		/// </summary>
		public HtmlReadonlyAttribute(string value) : base("readonly", value)
		{
		}
	}
}
