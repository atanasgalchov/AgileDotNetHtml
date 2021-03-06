using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileDotNetHtml.Interfaces
{
    public interface IHtmlBuilder
    {
        IHtmlContent CreateElement(IHtmlElement element);
    }
}
