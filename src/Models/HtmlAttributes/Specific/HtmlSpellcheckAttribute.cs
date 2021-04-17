using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("spellcheck")]
	public class HtmlSpellcheckAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlSpellcheckAttribute class represent HTML spellcheck attribute.
		/// </summary>
		public HtmlSpellcheckAttribute(string value) : base("spellcheck", value)
		{
		}
	}
}
