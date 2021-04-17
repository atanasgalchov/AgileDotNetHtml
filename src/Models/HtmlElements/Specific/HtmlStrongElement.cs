using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("strong")]
	public class HtmlStrongElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlStrongElement class represent HTML &lt;strong&gt; tag.
		/// </summary>
		public HtmlStrongElement() : base("strong") { }
	}
}

