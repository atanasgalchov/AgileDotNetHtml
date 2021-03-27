using AgileDotNetHtml.Extensions;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AgileDotNetHtml
{
	internal class HtmlHelper
	{
		internal const string startTagRegex = "(<[!]?[a-zA-Z]+)(>|.*?[^?]>)";
		internal const string endTagRegex = "((<[\\s]*\\/)[\\s]*\\w+([\\s]*>))";
		internal const string wholeTagRegex = "(<[!]?[a-zA-Z]+)(>|.*?[^?]>).*((<[\\s]*/)[\\s]*\\w+([\\s]*>))";
		internal const string keyValueAttributeEqualSymbolSpacingRegex = "[\\s]+=[\\s]+";

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
		internal string EncodeTagsContent(string tagName, string html)
		{
			if (Regex.IsMatch(html, GetRegexForStartTag("script")))
			{
				Match startScriptTag = Regex.Match(html, GetRegexForStartTag(tagName));
				Match endScriptTag = Regex.Match(html, GetRegexForEndTag(tagName));
				while (startScriptTag.Value.IsNotNullNorEmpty())
				{
					int startScriptContentIndex = startScriptTag.Index + startScriptTag.Value.Length;
					int endScriptContentIndex = endScriptTag.Index;
					string content = html.Substring(startScriptContentIndex, endScriptContentIndex - startScriptContentIndex);
					string encodedContent = HttpUtility.HtmlEncode(content);

					html = html.Remove(startScriptContentIndex, endScriptContentIndex - startScriptContentIndex);
					html = html.Insert(startScriptContentIndex, encodedContent);
					startScriptTag = startScriptTag.NextMatch();
					endScriptTag = endScriptTag.NextMatch();
				}
			}

			return html;
		}
		internal string GetRegexForEndTag(string tagName)
		{
			return "((<[\\s]*\\/)[\\s]*(" + tagName + "){1}([\\s]*>))";
		}
		internal string GetRegexForStartTag(string tagName)
		{
			return "(<[!]?(" + tagName + "){1})(>|.*?[^?]>)";
		}
	}
}
