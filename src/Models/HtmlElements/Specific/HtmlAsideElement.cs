using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("aside")]
	public class HtmlAsideElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlAsideElement class represent HTML &lt;aside&gt; tag.
		/// </summary>
		public HtmlAsideElement() : base("aside") { }
	}
}

