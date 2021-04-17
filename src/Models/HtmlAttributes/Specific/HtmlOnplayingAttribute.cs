using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onplaying", new string[] { "audio", "video" })]
	public class HtmlOnplayingAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnplayingAttribute class represent HTML onplaying attribute.
		/// </summary>
		public HtmlOnplayingAttribute(string value) : base("onplaying", value)
		{
		}
	}
}
