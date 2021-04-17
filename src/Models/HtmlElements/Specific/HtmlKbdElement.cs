using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("kbd")]
	public class HtmlKbdElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlKbdElement class represent HTML &lt;kbd&gt; tag.
		/// </summary>
		public HtmlKbdElement() : base("kbd") { }
	}
}

