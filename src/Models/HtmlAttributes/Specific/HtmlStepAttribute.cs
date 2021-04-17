using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("step", new string[] { "input" })]
	public class HtmlStepAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlStepAttribute class represent HTML step attribute.
		/// </summary>
		public HtmlStepAttribute(string value) : base("step", value)
		{
		}
	}
}
