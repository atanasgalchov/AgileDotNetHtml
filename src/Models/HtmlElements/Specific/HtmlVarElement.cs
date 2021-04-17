using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("var")]
	public class HtmlVarElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlVarElement class represent HTML &lt;var&gt; tag.
		/// </summary>
		public HtmlVarElement() : base("var") { }
	}
}

