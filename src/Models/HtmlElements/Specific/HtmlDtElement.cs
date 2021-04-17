using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("dt")]
	public class HtmlDtElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlDtElement class represent HTML &lt;dt&gt; tag.
		/// </summary>
		public HtmlDtElement() : base("dt") { }
	}
}

