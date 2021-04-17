using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("applet")]
	public class HtmlAppletElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlAppletElement class represent HTML &lt;applet&gt; tag.
		/// </summary>
		public HtmlAppletElement() : base("applet") { }
	}
}

