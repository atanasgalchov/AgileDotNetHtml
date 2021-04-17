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
		public IHtmlElement Head => FindFirst(x => x.TagName == "head");
		public IHtmlElement Title => FindFirst(x => x.TagName == "title");
		public IHtmlElement Body => FindFirst(x => x.TagName == "body");
		
	}
}
