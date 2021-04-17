using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("pre")]
	public class HtmlPreElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlPreElement class represent HTML &lt;pre&gt; tag.
		/// </summary>
		public HtmlPreElement() : base("pre") { }
	}
}

