using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("tr")]
	public class HtmlTrElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlTrElement class represent HTML &lt;tr&gt; tag.
		/// </summary>
		public HtmlTrElement() : base("tr") { }
	}
}

