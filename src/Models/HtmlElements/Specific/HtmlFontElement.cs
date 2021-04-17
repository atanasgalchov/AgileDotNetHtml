using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("font")]
	public class HtmlFontElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlFontElement class represent HTML &lt;font&gt; tag.
		/// </summary>
		public HtmlFontElement() : base("font") { }
	}
}

