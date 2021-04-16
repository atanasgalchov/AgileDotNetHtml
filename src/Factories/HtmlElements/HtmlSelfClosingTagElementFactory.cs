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

		protected virtual Type TypeForCreate { get { return typeof(HtmlSelfClosingTagElement); } }

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
				.FirstOrDefault(t => t.Name.ToLower() == $"Html{_tagName}Element".ToLower());

			if (specificType != null)
				return (IHtmlElement)Activator.CreateInstance(specificType);

			return (IHtmlElement)Activator.CreateInstance(TypeForCreate, new object[] { _tagName });
		}
	}
}
