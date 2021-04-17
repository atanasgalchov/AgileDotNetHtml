namespace AgileDotNetHtml.Interfaces
{
    public interface IHtmlAttribute
    {
        string Name { get; }
        string Value { get; set; }
        string WrapValueQuote { get; set; }
    }
}
