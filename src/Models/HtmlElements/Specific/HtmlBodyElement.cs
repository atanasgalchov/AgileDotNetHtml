using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("body")]
	public class HtmlBodyElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlBodyElement class represent HTML &lt;body&gt; tag.
		/// </summary>
		public HtmlBodyElement() : base("body") { }
	}
}

