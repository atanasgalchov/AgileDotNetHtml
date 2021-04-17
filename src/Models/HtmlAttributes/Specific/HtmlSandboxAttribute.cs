using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("sandbox", new string[] { "iframe" })]
	public class HtmlSandboxAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlSandboxAttribute class represent HTML sandbox attribute.
		/// </summary>
		public HtmlSandboxAttribute(string value) : base("sandbox", value)
		{
		}
	}
}
