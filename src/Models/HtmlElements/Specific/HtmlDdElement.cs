using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("dd")]
	public class HtmlDdElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlDdElement class represent HTML &lt;dd&gt; tag.
		/// </summary>
		public HtmlDdElement() : base("dd") { }
	}
}

