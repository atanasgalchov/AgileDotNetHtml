using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("poster", new string[] { "video" })]
	public class HtmlPosterAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlPosterAttribute class represent HTML poster attribute.
		/// </summary>
		public HtmlPosterAttribute(string value) : base("poster", value)
		{
		}
	}
}
