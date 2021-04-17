using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("download", new string[] { "a", "area" })]
	public class HtmlDownloadAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlDownloadAttribute class represent HTML download attribute.
		/// </summary>
		public HtmlDownloadAttribute(string value) : base("download", value)
		{
		}
	}
}
