using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	public class HtmlDocumentElementFactory : HtmlNodeElementFactory
	{
		public HtmlDocumentElementFactory() :base ("html")
		{
		}
	}
}
