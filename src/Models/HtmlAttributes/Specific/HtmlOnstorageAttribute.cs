using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("onstorage", new string[] { "body" })]
	public class HtmlOnstorageAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOnstorageAttribute class represent HTML onstorage attribute.
		/// </summary>
		public HtmlOnstorageAttribute(string value) : base("onstorage", value)
		{
		}
	}
}
