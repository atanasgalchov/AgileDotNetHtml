using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("select")]
	public class HtmlSelectElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlSelectElement class represent HTML &lt;select&gt; tag.
		/// </summary>
		public HtmlSelectElement() : base("select") { }
	}
}

