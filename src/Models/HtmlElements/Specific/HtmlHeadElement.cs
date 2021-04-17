using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("head")]
	public class HtmlHeadElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlHeadElement class represent HTML &lt;head&gt; tag.
		/// </summary>
		public HtmlHeadElement() : base("head") { }
	}
}

