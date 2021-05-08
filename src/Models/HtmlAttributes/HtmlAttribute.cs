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
		public string WrapValueQuote { get; set; } = "\"";
	}
}
