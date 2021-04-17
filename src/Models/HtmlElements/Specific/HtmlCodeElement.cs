using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("code")]
	public class HtmlCodeElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlCodeElement class represent HTML &lt;code&gt; tag.
		/// </summary>
		public HtmlCodeElement() : base("code") { }
	}
}

