using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("oncuechange", new string[] { "track" })]
	public class HtmlOncuechangeAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOncuechangeAttribute class represent HTML oncuechange attribute.
		/// </summary>
		public HtmlOncuechangeAttribute(string value) : base("oncuechange", value)
		{
		}
	}
}
