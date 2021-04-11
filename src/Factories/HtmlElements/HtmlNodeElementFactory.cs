using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;
using Microsoft.AspNetCore.Html;
using System.Collections.Generic;

namespace AgileDotNetHtml.Factories.HtmlElements
{
	public class HtmlNodeElementFactory : HtmlPairTagsElementFactory
	{
		public HtmlNodeElementFactory(string tagName) : base(tagName)
		{
		}

		public override IHtmlElement Create(HtmlAttributesCollection attributes, string html, int startContentIndex, int endContentIndex, HtmlParserManager htmlParserManager)
		{
			HtmlNodeElement element = new HtmlNodeElement(_tagName);
			
			// add children and texts
			if (endContentIndex - startContentIndex > 0) 
			{
				element.Children = htmlParserManager.Parse(startContentIndex, endContentIndex);
				Dictionary<int, string> texts = htmlParserManager.ParseText(startContentIndex, endContentIndex);
				foreach (var text in texts) 
				{
					if(text.Key >= 0)
						element.Text(new HtmlString(text.Value), element.Children[text.Key].UId);
					else
						element.Text(new HtmlString(text.Value));
				}					
			}
				
			element.Attributes = attributes;

			return element;
		}
	}
}
