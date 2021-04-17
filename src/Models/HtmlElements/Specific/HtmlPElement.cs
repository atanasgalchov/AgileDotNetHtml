using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("p")]
	public class HtmlPElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlPElement class represent HTML &lt;p&gt; tag.
		/// </summary>
		public HtmlPElement() : base("p") { }
	}
}

