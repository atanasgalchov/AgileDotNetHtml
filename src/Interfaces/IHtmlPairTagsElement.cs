using Microsoft.AspNetCore.Html;

namespace AgileDotNetHtml.Interfaces
{
	public interface IHtmlPairTagsElement
	{
		HtmlString Text();
		public void Text(string html);
		void Text(HtmlString html);
	}
}
