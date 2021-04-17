using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("em")]
	public class HtmlEmElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlEmElement class represent HTML &lt;em&gt; tag.
		/// </summary>
		public HtmlEmElement() : base("em") { }
	}
}

