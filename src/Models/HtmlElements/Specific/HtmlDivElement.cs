using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("div")]
	public class HtmlDivElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlDivElement class represent HTML &lt;div&gt; tag.
		/// </summary>
		public HtmlDivElement() : base("div") { }
	}
}

