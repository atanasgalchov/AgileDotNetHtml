using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("tt")]
	public class HtmlTtElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlTtElement class represent HTML &lt;tt&gt; tag.
		/// </summary>
		public HtmlTtElement() : base("tt") { }
	}
}

