using AgileDotNetHtml.Extensions;
using System.Linq;
using System.Text.RegularExpressions;

namespace AgileDotNetHtml
{
	internal class HtmlHelper
	{
		private string[] _selfClosingTagNames = new string[] 
		{
			"area",
			"base",
			"br",
			"embed",
			"hr",
			"iframe",
			"img",
			"input",
			"link",
			"meta",
			"param",
			"source",
			"track"
		};
		
		internal HtmlHelper()
		{

		}
		internal HtmlHelper(string[] selfClosingTagNames)
		{
			_selfClosingTagNames = selfClosingTagNames;
		}

		internal string[] SelfClosingTagNames 
		{ 
			get { return _selfClosingTagNames; } 
			set { _selfClosingTagNames = value;  } 
		}
		
		internal bool IsSelfClosingHtmlTag(string tagName) => SelfClosingTagNames.Any(x => TrimHtmlTag(x).IsEqualIgnoreCase(tagName));
		internal string TrimHtmlTag(string tagName) => Regex.Replace(tagName, @"\s+|/+", "").TrimStart('<').TrimEnd('>');

	}
}
