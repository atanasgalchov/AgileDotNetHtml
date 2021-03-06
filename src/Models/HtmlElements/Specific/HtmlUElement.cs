using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("u")]
	public class HtmlUElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlUElement class represent HTML &lt;u&gt; tag.
		/// </summary>
		public HtmlUElement() : base("u") { }
	}
}

