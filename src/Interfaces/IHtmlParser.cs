using System;
using System.Collections.Generic;
using System.Text;

namespace AgileDotNetHtml.Interfaces
{
	interface IHtmlParser
	{
		IHtmlElementsCollection ParseString(string html);
	}
}
