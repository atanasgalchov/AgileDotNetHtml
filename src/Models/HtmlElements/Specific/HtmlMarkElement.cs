using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("mark")]
	public class HtmlMarkElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlMarkElement class represent HTML &lt;mark&gt; tag.
		/// </summary>
		public HtmlMarkElement() : base("mark") { }
	}
}

