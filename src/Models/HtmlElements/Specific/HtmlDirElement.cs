using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("dir")]
	public class HtmlDirElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlDirElement class represent HTML &lt;dir&gt; tag.
		/// </summary>
		public HtmlDirElement() : base("dir") { }
	}
}

