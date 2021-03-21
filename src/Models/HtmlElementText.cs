using Microsoft.AspNetCore.Html;

namespace AgileDotNetHtml.Models
{
	public class HtmlElementText
	{
		public int Index { get; set; }
		public HtmlString HtmlString { get; set; }
		
		public HtmlElementText(HtmlString htmlString)
		{
			HtmlString = htmlString;
		}
		public HtmlElementText(HtmlString htmlString, int index)
		{
			HtmlString = htmlString;
			Index = index;
		}

		public static implicit operator HtmlString(HtmlElementText text)
		{
			return text.HtmlString;
		}
	}
}
