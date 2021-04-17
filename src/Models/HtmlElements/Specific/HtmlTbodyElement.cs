using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("tbody")]
	public class HtmlTbodyElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlTbodyElement class represent HTML &lt;tbody&gt; tag.
		/// </summary>
		public HtmlTbodyElement() : base("tbody") { }
	}
}

