using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("picture")]
	public class HtmlPictureElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlPictureElement class represent HTML &lt;picture&gt; tag.
		/// </summary>
		public HtmlPictureElement() : base("picture") { }
	}
}

