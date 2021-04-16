using AgileDotNetHtml.Interfaces;

namespace AgileDotNetHtml.Models.HtmlAttributes
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
	public class ClassHtmlAttribute : HtmlAttribute
	{
		public ClassHtmlAttribute(string value): base("class", value)
		{
		}
	}
	public class StyleHtmlAttribute : HtmlAttribute
	{
		public StyleHtmlAttribute(string value) : base("style", value)
		{
		}
	}
	public class NameHtmlAttribute : HtmlAttribute
	{
		public NameHtmlAttribute(string value) : base("name", value)
		{
		}
	}
	public class IdHtmlAttribute : HtmlAttribute
	{
		public IdHtmlAttribute(string value) : base("id", value)
		{
		}
	}
	public class TypeHtmlAttribute : HtmlAttribute
	{
		public TypeHtmlAttribute(string value) : base("type", value)
		{
		}
	}
	public class DisabledHtmlAttribute : HtmlAttribute
	{
		public DisabledHtmlAttribute(string value) : base("disabled", value)
		{
		}
	}
	public class CheckedHtmlAttribute : HtmlAttribute
	{
		public CheckedHtmlAttribute(string value) : base("checked", value)
		{
		}
	}
}
