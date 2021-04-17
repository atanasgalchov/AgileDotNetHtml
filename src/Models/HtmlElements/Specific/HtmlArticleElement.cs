using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("article")]
	public class HtmlArticleElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlArticleElement class represent HTML &lt;article&gt; tag.
		/// </summary>
		public HtmlArticleElement() : base("article") { }
	}
}

