using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;

namespace AgileDotNetHtml.ClassFactory
{
	public class HtmlElementFactory : IHtmlElementFactory
	{
		private string _name;
		public HtmlElementFactory(string name)
		{
			_name = name;
		}

		public virtual IHtmlElement Create()
		{
			HtmlElement element = new HtmlElement(_name);
			return element;
		}
	}
}
