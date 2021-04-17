using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("cite", new string[] { "del", "ins" })]
	public class HtmlCiteAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlCiteAttribute class represent HTML cite attribute.
		/// </summary>
		public HtmlCiteAttribute(string value) : base("cite", value)
		{
		}
	}
}
