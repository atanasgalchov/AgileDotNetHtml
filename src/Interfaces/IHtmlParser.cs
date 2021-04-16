namespace AgileDotNetHtml.Interfaces
{
	public interface IHtmlParser
	{
		IHtmlElementsCollection ParseString(string html);
	}
}
