using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("nav")]
	public class HtmlNavElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlNavElement class represent HTML &lt;nav&gt; tag.
		/// </summary>
		public HtmlNavElement() : base("nav") { }
	}
}

