using System.Collections.Generic;

namespace AgileDotNetHtml.Interfaces
{
    public interface IHtmlStandarts
    {
        string HtmlVersion { get;  }
        string[] AllTags { get;}
        IDictionary<string, string[]> AttributeTags { get; }
        string[] SelfClosingTags { get;}
        string[] InputTypes { get; }
    }
}
