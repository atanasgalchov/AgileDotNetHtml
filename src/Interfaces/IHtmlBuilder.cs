using Microsoft.AspNetCore.Html;

namespace AgileDotNetHtml.Interfaces
{
	public interface IHtmlBuilder
    {
        IHtmlContent CreateHtmlContent(IHtmlElement element);
    }
}
