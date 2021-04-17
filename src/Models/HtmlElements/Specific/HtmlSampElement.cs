using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("samp")]
	public class HtmlSampElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlSampElement class represent HTML &lt;samp&gt; tag.
		/// </summary>
		public HtmlSampElement() : base("samp") { }
	}
}

