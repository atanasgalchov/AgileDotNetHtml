using Microsoft.AspNetCore.Html;

namespace AgileDotNetHtml.Models
{
	public class HtmlElementText
	{
		public HtmlElementText(HtmlString htmlString)
		{
			HtmlString = htmlString;
		}
		public HtmlElementText(HtmlString htmlString, string afterElementUId)
		{
			HtmlString = htmlString;
			AfterElementUId = afterElementUId;
		}

		public HtmlString HtmlString { get; set; }
		public string AfterElementUId { get; set; }
	}
}
