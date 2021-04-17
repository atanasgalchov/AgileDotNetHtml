using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("i")]
	public class HtmlIElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlIElement class represent HTML &lt;i&gt; tag.
		/// </summary>
		public HtmlIElement() : base("i") { }
	}
}

