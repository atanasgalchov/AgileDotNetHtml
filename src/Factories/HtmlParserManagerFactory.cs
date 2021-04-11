namespace AgileDotNetHtml.Factories
{
	internal class HtmlParserManagerFactory
	{
		internal HtmlParserManager Create(string htmlString)
		{
			return new HtmlParserManager(htmlString);
		}
	}
}
