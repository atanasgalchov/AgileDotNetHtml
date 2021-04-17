using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("srcdoc", new string[] { "iframe" })]
	public class HtmlSrcdocAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlSrcdocAttribute class represent HTML srcdoc attribute.
		/// </summary>
		public HtmlSrcdocAttribute(string value) : base("srcdoc", value)
		{
		}
	}
}
