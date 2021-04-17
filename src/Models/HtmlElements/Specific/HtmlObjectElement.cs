using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("object")]
	public class HtmlObjectElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlObjectElement class represent HTML &lt;object&gt; tag.
		/// </summary>
		public HtmlObjectElement() : base("object") { }
	}
}

