using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("template")]
	public class HtmlTextareaElement : HtmlNodeElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlTextareaElement class represent HTML &lt;textarea&gt; tag.
		/// </summary>
		public HtmlTextareaElement() : base("template") { }

		public string Name
		{
			get
			{
				return GetAttribute("name")?.Value;
			}
			set
			{
				AddAttributeValue("name", value);
			}
		}
	}
}
