using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("srcset", new string[] { "img", "source" })]
	public class HtmlSrcsetAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlSrcsetAttribute class represent HTML srcset attribute.
		/// </summary>
		public HtmlSrcsetAttribute(string value) : base("srcset", value)
		{
		}
	}
}
