using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("open", new string[] { "details" })]
	public class HtmlOpenAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOpenAttribute class represent HTML open attribute.
		/// </summary>
		public HtmlOpenAttribute(string value) : base("open", value)
		{
		}
	}
}
