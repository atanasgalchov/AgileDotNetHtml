using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("ondragover")]
	public class HtmlOndragoverAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlOndragoverAttribute class represent HTML ondragover attribute.
		/// </summary>
		public HtmlOndragoverAttribute(string value) : base("ondragover", value)
		{
		}
	}
}
