using AgileDotNetHtml.Helpers.Extensions;
using System.Linq;
using System.Text.RegularExpressions;

namespace AgileDotNetHtml.Helpers
{
	internal class HtmlHelper
	{
		private string[] _selfClosingTagNames = new string[] 
		{
			"!doctype",
			"area",		
			"base",
			"br",
			"col",
			"embed",
			"hr",
			"img",
			"input",
			"link",
			"path",
			"meta",
			"param",
			"rb",
			"rt",
			"source",
			"track",
			"wbr"
		};
		private string[] _tagsWhitPotentialInvalidHtmlInside = new string[]
		{
			"script",
			"code",
			"textarea"		
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
		internal string[] TagsWhitPotentialInvalidHtmlInside
		{
			get { return _tagsWhitPotentialInvalidHtmlInside; }
			set { _tagsWhitPotentialInvalidHtmlInside = value; }
		}
		internal bool IsSelfClosingHtmlTag(string tagName) => SelfClosingTagNames.Any(x => TrimHtmlTag(x).IsEqualIgnoreCase(tagName));
		internal string TrimHtmlTag(string tagName) => Regex.Replace(tagName, @"\s+|/+", "").TrimStart('<').TrimEnd('>');
		/// <summary>
		/// Extract tag name string.
		/// </summary>
		/// <param name="startTag">Html start tag string. Example <span>, <div class="div">, ect. </param>
		/// <returns cref="string">Name of given startTag.</returns>
		internal string ExtractTagNameFromStartTag(string startTag)
		{
			// remove start char
			startTag = startTag.Trim().TrimStart('<');
			// get tag name
			return startTag.Split(new char[] { ' ', '/', '>' }).FirstOrDefault();
		}
		internal string ExtractTagNameFromEndTag(string startTag)
		{
			// remove start char
			return startTag.Trim().TrimStart('<').TrimStart().TrimStart('/').TrimEnd('>').Trim();
		}
		internal string GetRegexForEndTag(string tagName)
		{
			return "((<[\\s]*\\/)[\\s]*(" + tagName + "){1}([\\s]*>))";
		}
		internal string GetRegexForStartTag(string tagName)
		{
			return "(<[!]?(" + tagName + "){1})(>|.*?[^?]>)";
		}
		internal string GetNameValueAttributeRegex(string name)
		{
			return "(" + name + "[\\s]*=[\\s]*)(['\"])?";
		}
		internal string GetEmptyValueAttributeRegex(string name)
		{
			return "(" + name + "[\\s]*=[\\s]*)(['\"][\\s]*['\"])";
		}
	}
}
