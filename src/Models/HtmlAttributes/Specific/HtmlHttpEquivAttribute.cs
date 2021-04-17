using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("http-equiv", new string[] { "meta" })]
	public class HtmlHttpEquivAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlHttp-equivAttribute class represent HTML http-equiv attribute.
		/// </summary>
		public HtmlHttpEquivAttribute(string value) : base("http-equiv", value)
		{
		}
	}
}
