using AgileDotNetHtml.Helpers;
using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using System.Text.RegularExpressions;

namespace AgileDotNetHtml.Factories.HtmlAttributes
{
	internal class HtmlAttributeFactory : IHtmlAttributeFactory
	{
		private string _name;
		private HtmlHelper _htmlHelper;

		internal HtmlAttributeFactory(string name)
		{
			_htmlHelper = new HtmlHelper();
			_name = name;
		}

		public virtual IHtmlAttribute Create(string nameValueAttributesString) 
		{
			string value = null;
			string openQuote = null;
			Match match = Regex.Match(nameValueAttributesString, _htmlHelper.GetNameValueAttributeRegex(_name));
			if (match.Value.Length > 0 && !Regex.IsMatch(nameValueAttributesString, _htmlHelper.GetEmptyValueAttributeRegex(_name)))
			{
				// when value is not wraped whit quotes
				if (!match.Groups[2].Success)
				{
					// get string after equal symbol and first space
					value = nameValueAttributesString
							.SubStringToIndex(match.Index + match.Value.Length, nameValueAttributesString.IndexOf(" ") == -1 ? nameValueAttributesString.Length -1 : nameValueAttributesString.IndexOf(" "));
				}
				// when value is wraped whit quotes
				else
				{
					openQuote = match.Groups[2].Value;
					// get closing quote, closing quote is first after opened
					int closingQuoteIndex = nameValueAttributesString.IndexOf(openQuote, match.Groups[2].Index + 1);
					// get string between quotes
					value = nameValueAttributesString.Substring(match.Groups[2].Index + 1, (closingQuoteIndex - match.Groups[2].Index) - 1);
				}
			}
			IHtmlAttribute attribute = new HtmlAttribute(_name, value);
			attribute.WrapValueQuote = openQuote;

			return attribute;
		}
	}
}
