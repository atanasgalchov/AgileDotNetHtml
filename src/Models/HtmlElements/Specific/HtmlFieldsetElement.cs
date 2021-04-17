using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("fieldset")]
	public class HtmlFieldsetElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlFieldsetElement class represent HTML &lt;fieldset&gt; tag.
		/// </summary>
		public HtmlFieldsetElement() : base("fieldset") { }
	}
}

