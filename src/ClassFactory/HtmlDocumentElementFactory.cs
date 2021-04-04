using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;

namespace AgileDotNetHtml.ClassFactory
{
	public class HtmlDocumentElementFactory : HtmlElementFactory
	{
		public HtmlDocumentElementFactory() :base ("html")
		{
		}

		public override IHtmlElement Create()
		{
			HtmlDocument document = new HtmlDocument();
			return document;
		}
	}
}
