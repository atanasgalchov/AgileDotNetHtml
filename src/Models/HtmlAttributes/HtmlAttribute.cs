using AgileDotNetHtml.Interfaces;

namespace AgileDotNetHtml.HtmlAttributes
{
	public class HtmlAttribute : IHtmlAttribute
	{
		public HtmlAttribute(string name)
		{
			Name = name.Trim();
		}
		public HtmlAttribute(string name, string value) : this(name)
		{
			Value = value?.Trim();
		}

		public string Name { get; set; }
		public string Value { get; set; }
	}
	public class Class : HtmlAttribute
	{
		public Class(string value): base("class", value)
		{
		}
	}
	public class Name : HtmlAttribute
	{
		public Name(string value) : base("name", value)
		{
		}
	}
	public class Id : HtmlAttribute
	{
		public Id(string value) : base("id", value)
		{
		}
	}
	public class Type : HtmlAttribute
	{
		public Type(string value) : base("type", value)
		{
		}
	}
}
