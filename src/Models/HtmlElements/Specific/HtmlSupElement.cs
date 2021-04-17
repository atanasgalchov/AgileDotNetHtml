using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("sup")]
	public class HtmlSupElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlSupElement class represent HTML &lt;sup&gt; tag.
		/// </summary>
		public HtmlSupElement() : base("sup") { }
	}
}

