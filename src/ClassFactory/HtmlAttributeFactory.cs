using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using System.Text.RegularExpressions;

namespace AgileDotNetHtml.ClassFactory
{
	public class HtmlAttributeFactory : IHtmlAttributeFactory
	{
		private string _name;

		public HtmlAttributeFactory(string name)
		{
			_name = name;
		}
		public virtual IHtmlAttribute Create(string nameValueAttributesString) 
		{
			string value = null;
			Match match = Regex.Match(nameValueAttributesString, GetNameValueAttributeRegex());
			if (match.Value.Length > 0 && !Regex.IsMatch(nameValueAttributesString, GetEmptyValueAttributeRegex())) 
			{
				string openQuote = match.Groups[2].Value;
				// get closing quote, closing quote is first after opened
				int closingQuoteIndex = nameValueAttributesString.IndexOf(openQuote, match.Groups[2].Index + 1);
				// get string between quotes
				value = nameValueAttributesString.Substring(match.Groups[2].Index + 1, (closingQuoteIndex - match.Groups[2].Index) - 1);
			}	
						
			return new HtmlAttribute(_name, value);
		}

		protected string GetNameValueAttributeRegex() 
		{
			return "(" + _name + "[\\s]*=[\\s]*)(['\"])";
		}
		protected string GetEmptyValueAttributeRegex() 
		{
			return "(" + _name + "[\\s]*=[\\s]*)(['\"][\\s]*['\"])";
		}
	}
}
