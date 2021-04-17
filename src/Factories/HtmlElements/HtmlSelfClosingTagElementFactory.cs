using AgileDotNetHtml.Attributes;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;
using System;
using System.Linq;
using System.Reflection;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	internal class HtmlSelfClosingTagElementFactory : IHtmlSelfClosingTagElementFactory
	{
		protected string _tagName;
		internal HtmlSelfClosingTagElementFactory(string tagName)
		{
			_tagName = tagName;
		}

		protected virtual Type DefaultTypeForCreate { get { return typeof(HtmlSelfClosingTagElement); } }

		public virtual IHtmlElement Create(HtmlAttributesCollection attributes, string html, IHtmlParserManager htmlParserManager)
		{
			IHtmlElement element = (HtmlSelfClosingTagElement)CreateInstance();
			element.Attributes = attributes;
			return element;
		}
		protected virtual IHtmlElement CreateInstance()
		{
			Type specificType = Assembly.GetCallingAssembly()
				.GetTypes()
				.Where(t => t.GetCustomAttribute<HtmlElementClassAttribute>() != null)
				.FirstOrDefault(t => t.GetCustomAttribute<HtmlElementClassAttribute>().TagName == _tagName);

			if (specificType != null)
				return (IHtmlElement)Activator.CreateInstance(specificType);

			return (IHtmlElement)Activator.CreateInstance(DefaultTypeForCreate, new object[] { _tagName });
		}
	}
}
