using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("noframes")]
	public class HtmlNoFramesElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlNoFramesElement class represent HTML &lt;noframes&gt; tag.
		/// </summary>
		public HtmlNoFramesElement() : base("noframes") { }
	}
}

