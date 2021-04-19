using System.Collections.Generic;

namespace AgileDotNetHtml.Interfaces
{
	public interface IHtmlParserManager
	{
		string Html { get; set; }
		IHtmlElementsCollection Parse();
		IHtmlElementsCollection ParseElements(int startIndex, int endIndex);
		Dictionary<int, string> ParseText(int startIndex, int endIndex);
	}
}
