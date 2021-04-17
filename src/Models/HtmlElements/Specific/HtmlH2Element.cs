using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("h2")]
	public class HtmlH2Element : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlH2Element class represent HTML &lt;h2&gt; tag.
		/// </summary>
		public HtmlH2Element() : base("h2") { }
	}
}

