using Microsoft.AspNetCore.Html;

namespace AgileDotNetHtml.Interfaces
{
	public interface IHtmlPairTagsElement
	{
		HtmlString Text();
		public void Text(string html, bool decode = false);
		void Text(HtmlString html, bool decode = false);
	}
}
