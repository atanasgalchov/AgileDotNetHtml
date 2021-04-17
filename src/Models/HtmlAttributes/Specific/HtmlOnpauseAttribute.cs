using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onpause", new string[] { "audio", "video" })]
	public class HtmlOnpauseAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnpauseAttribute class represent HTML onpause attribute.
		/// </summary>
		public HtmlOnpauseAttribute(string value) : base("onpause", value)
		{
		}
	}
}
