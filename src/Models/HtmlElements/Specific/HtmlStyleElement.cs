using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("style")]
	public class HtmlStyleElement: HtmlPairTagsElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlStyleElement class represent HTML &lt;style&gt; tag.
		/// </summary>
		public HtmlStyleElement() : base("style")
		{
		}
	}
}
