using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ontimeupdate", new string[] { "audio", "video" })]
	public class HtmlOntimeupdateAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOntimeupdateAttribute class represent HTML ontimeupdate attribute.
		/// </summary>
		public HtmlOntimeupdateAttribute(string value) : base("ontimeupdate", value)
		{
		}
	}
}
