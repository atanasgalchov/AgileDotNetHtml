using System.Collections.Generic;

namespace AgileDotNetHtml.Interfaces
{
	public interface IHtmlParserManager
	{
		IHtmlElementsCollection Parse();
		IHtmlElementsCollection Parse(int startIndex, int endIndex);
		Dictionary<int, string> ParseText(int startIndex, int endIndex);
	}
}
