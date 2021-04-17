using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("output")]
	public class HtmlOutputElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlOutputElement class represent HTML &lt;output&gt; tag.
		/// </summary>
		public HtmlOutputElement() : base("output") { }
	}
}

