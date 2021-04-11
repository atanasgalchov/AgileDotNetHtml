using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using AgileDotNetHtml.Models.HtmlElements;
using Microsoft.AspNetCore.Html;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

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
					string decodedText = HttpUtility.HtmlDecode(text.Value);
					string value = text.Value;
					if (Regex.IsMatch(decodedText, HtmlParserManager.commentRegex))
						value = decodedText;

					if (text.Key >= 0)
						element.Text(new HtmlString(value), element.Children[text.Key].UId);
					else
						element.Text(new HtmlString(value));
				}					
			}
				
			element.Attributes = attributes;

			return element;
		}
	}
}
