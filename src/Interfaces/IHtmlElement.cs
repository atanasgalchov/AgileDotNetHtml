namespace AgileDotNetHtml.Interfaces
{
	public interface IHtmlElement
    {
        string UId { get; }
        string TagName { get; }
        IHtmlElementsCollection Parents { get; }
        IHtmlAttribute[] Attributes { get; set; }
        void AddAttribute(IHtmlAttribute attribute);
        void AddAttributeValue(string Name, string Value);
        bool HasAttribute(string Name);
        IHtmlAttribute GetAttribute(string Name);
        void ReplaceAttributeValue(string Name, string Value);
        void RemoveAttribute(string Name);
        void AddRangeAttributes(IHtmlAttribute[] Attributes);
    }
}
