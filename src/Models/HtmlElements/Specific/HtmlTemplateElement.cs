using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("template")]
	public class HtmlTemplateElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlTemplateElement class represent HTML &lt;template&gt; tag.
		/// </summary>
		public HtmlTemplateElement() : base("template") { }
	}
}

