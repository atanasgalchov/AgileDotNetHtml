using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("dir")]
	public class HtmlDirAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlDirAttribute class represent HTML dir attribute.
		/// </summary>
		public HtmlDirAttribute(string value) : base("dir", value)
		{
		}
	}
}
