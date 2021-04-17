using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("ruby")]
	public class HtmlRubyElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlRubyElement class represent HTML &lt;ruby&gt; tag.
		/// </summary>
		public HtmlRubyElement() : base("ruby") { }
	}
}

