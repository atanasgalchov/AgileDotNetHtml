namespace AgileDotNetHtml.Interfaces
{
	public interface IHtmlElement
    {
        string UId { get; }
        string TagName { get; }
        IHtmlElementsCollection Parents { get; }
        IHtmlAttribute[] Attributes { get; set; }
        void AddAttribute(IHtmlAttribute attribute);
        void AddAttribute(string name);
        void AddAttributeValue(string name, string value);
        bool HasAttribute(string name);
        bool HasAttributeWhitValue(string name, string value);
        IHtmlAttribute GetAttribute(string name);
        void ReplaceAttributeValue(string name, string value);
        void RemoveAttribute(string name);
        void AddRangeAttributes(IHtmlAttribute[] attributes);
    }
}
