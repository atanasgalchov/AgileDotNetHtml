using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("audio")]
	public class HtmlAudioElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlAudioElement class represent HTML &lt;audio&gt; tag.
		/// </summary>
		public HtmlAudioElement() : base("audio") { }
	}
}

