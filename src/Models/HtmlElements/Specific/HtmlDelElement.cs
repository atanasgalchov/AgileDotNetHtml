using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("del")]
	public class HtmlDelElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlDelElement class represent HTML &lt;del&gt; tag.
		/// </summary>
		public HtmlDelElement() : base("del") { }
	}
}

