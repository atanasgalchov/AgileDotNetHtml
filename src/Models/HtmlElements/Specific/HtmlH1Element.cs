using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("h1")]
	public class HtmlH1Element : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlH1Element class represent HTML &lt;h1&gt; tag.
		/// </summary>
		public HtmlH1Element() : base("h1") { }
	}
}

