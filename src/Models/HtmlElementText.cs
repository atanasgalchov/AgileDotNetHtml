using Microsoft.AspNetCore.Html;

namespace AgileDotNetHtml.Models
{
	public class HtmlElementText
	{
		public int Index { get; set; }
		public HtmlString htmlString { get; set; }


		public static implicit operator HtmlString(HtmlElementText text)
		{
			return text.htmlString;
		}
	}
}
