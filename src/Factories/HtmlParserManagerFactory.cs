using AgileDotNetHtml.Interfaces;

namespace AgileDotNetHtml.Factories
{
	internal class HtmlParserManagerFactory
	{
		internal IHtmlParserManager Create(string htmlString)
		{
			return new HtmlParserManager(htmlString);
		}
	}
}
