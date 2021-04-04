using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;


namespace AgileDotNetHtml.ClassFactory
{
	public class HtmlDoctypeElementFactory : HtmlElementFactory
	{
		public HtmlDoctypeElementFactory(): base("!DOCTYPE")
		{
		}

		public override IHtmlElement Create()
		{
			HtmlDoctypeElement document = new HtmlDoctypeElement();
			return document;
		}
	}
}
