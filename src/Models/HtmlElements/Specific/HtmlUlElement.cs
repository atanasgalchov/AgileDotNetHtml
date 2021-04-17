using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("ul")]
	public class HtmlUlElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlUlElement class represent HTML &lt;ul&gt; tag.
		/// </summary>
		public HtmlUlElement() : base("ul") { }
	}
}

