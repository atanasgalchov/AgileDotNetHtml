namespace AgileDotNetHtml.Interfaces
{
	interface IHtmlParser
	{
		IHtmlElementsCollection ParseString(string html);
	}
}
