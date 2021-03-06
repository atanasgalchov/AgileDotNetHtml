using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("form")]
	public class HtmlFormElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlFormElement class represent HTML &lt;form&gt; tag.
		/// </summary>
		public HtmlFormElement() : base("form") { }
	}
}

