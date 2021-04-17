using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("acronym")]
	public class HtmlAcronymElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlAcronymElement class represent HTML &lt;acronym&gt; tag.
		/// </summary>
		public HtmlAcronymElement() : base("acronym") { }
	}
}

