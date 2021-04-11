using AgileDotNetHtml.Interfaces;

namespace AgileDotNetHtml.Models.HtmlElements
{
	public class HtmlDocument : HtmlNodeElement
	{
		public HtmlDocument() : base("html")
		{
		}
		public HtmlDocument(IHtmlElement doctype): this()
		{
			Doctype = doctype;
		}

		public override HtmlElement Clone()
		{
			return (HtmlElement)this.MemberwiseClone();
		}

		public IHtmlElement Doctype { get; set; }
		public IHtmlElement Head => Find(x => x.TagName == "head");
		public IHtmlElement Title => Find(x => x.TagName == "title");
		public IHtmlElement Body => Find(x => x.TagName == "body");
	}
}
