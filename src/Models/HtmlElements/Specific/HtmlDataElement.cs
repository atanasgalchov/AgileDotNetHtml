using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("data")]
	public class HtmlDataElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlDataElement class represent HTML &lt;data&gt; tag.
		/// </summary>
		public HtmlDataElement() : base("data") { }
	}
}

