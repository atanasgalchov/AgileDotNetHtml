using Microsoft.AspNetCore.Html;

namespace AgileDotNetHtml.Models
{
	public class HtmlNodeElementText
	{
		public HtmlNodeElementText(HtmlString htmlString)
		{
			HtmlString = htmlString;
		}
		public HtmlNodeElementText(HtmlString htmlString, string afterElementUId)
		{
			HtmlString = htmlString;
			AfterElementUId = afterElementUId;
		}

		public HtmlString HtmlString { get; set; }
		public string AfterElementUId { get; set; }
	}
}
