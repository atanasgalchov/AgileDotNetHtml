using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("noscript")]
	public class HtmlNoScriptElement : HtmlPairTagsElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlNoScriptElement class represent HTML &lt;noscript&gt; tag.
		/// </summary>
		public HtmlNoScriptElement() : base("noscript")
		{
		}
	}
}
