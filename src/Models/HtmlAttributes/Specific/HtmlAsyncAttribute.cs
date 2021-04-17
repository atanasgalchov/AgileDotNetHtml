using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("async", new string[] { "script" })]
	public class HtmlAsyncAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlAsyncAttribute class represent HTML async attribute.
		/// </summary>
		public HtmlAsyncAttribute(string value) : base("async", value)
		{
		}
	}
}
