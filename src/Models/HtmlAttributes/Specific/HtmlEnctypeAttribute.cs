using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("enctype", new string[] { "form" })]
	public class HtmlEnctypeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlEnctypeAttribute class represent HTML enctype attribute.
		/// </summary>
		public HtmlEnctypeAttribute(string value) : base("enctype", value)
		{
		}
	}
}
