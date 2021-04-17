using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("address")]
	public class HtmlAddressElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlAddressElement class represent HTML &lt;address&gt; tag.
		/// </summary>
		public HtmlAddressElement() : base("address") { }
	}
}

