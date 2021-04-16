using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;
using System;
using System.Linq;
using System.Reflection;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	internal class HtmlPairTagsElementFactory : IHtmlPairTagsElementFactory
	{
		protected string _tagName;

		internal HtmlPairTagsElementFactory(string tagName)
		{
			_tagName = tagName;
		}

		protected virtual Type TypeForCreate { get { return typeof(HtmlPairTagsElement); } }

		public virtual IHtmlElement Create(HtmlAttributesCollection attributes, string html, int startContentIndex, int endContentIndex, IHtmlParserManager htmlParserManager)
		{
			HtmlPairTagsElement element = (HtmlPairTagsElement)CreateInstance();
			element.Attributes = attributes;
			element.Text(html.SubStringToIndex(startContentIndex, endContentIndex - 1));
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
