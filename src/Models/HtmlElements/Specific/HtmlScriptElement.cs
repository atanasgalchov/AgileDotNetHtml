using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("script")]
	public class HtmlScriptElement : HtmlPairTagsElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlScriptElement class represent HTML &lt;script&gt; tag.
		/// </summary>
		public HtmlScriptElement() : base("script")
		{
		}
	}
}
