using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("time")]
	public class HtmlTimeElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlTimeElement class represent HTML &lt;time&gt; tag.
		/// </summary>
		public HtmlTimeElement() : base("time") { }
	}
}
