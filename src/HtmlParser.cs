using AgileDotNetHtml.Factories;
using AgileDotNetHtml.Helpers.Extensions;
using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlElements;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AgileDotNetHtml
{
	public class HtmlParser : IHtmlParser
	{
		private HttpClient _httpClient;
		private HtmlParserManagerFactory _parserManagerFactory;

		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.HtmlParser class.
		/// </summary>
		public HtmlParser()
		{
			_httpClient = HttpClientFactory.Create();
			_parserManagerFactory = new HtmlParserManagerFactory();
		}
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.HtmlParser class.
		/// </summary>
		/// <param name="httpClientFactory">Instance of IHttpClientFactory for create http client.</param>
		public HtmlParser(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient();
			_parserManagerFactory = new HtmlParserManagerFactory();
		}

		public HtmlDocument ParsePageFromUrl(string url) 
		{
			if (url.IsNullOrEmpty())
				throw new ArgumentNullException("url");

			Task<HttpResponseMessage> responseTask = _httpClient.GetAsync(url);
			HttpResponseMessage response = responseTask.Result;
			string content = response.Content.ReadAsStringAsync().Result;

			return ParsePage(content);
		}
		/// <summary>
		/// Convert html document string to HtmlDocument.
		/// </summary>
		/// <param name="html">Valid html document string.</param>
		/// <returns cref="HtmlDocument">HtmlDocument instance represent given html string.</returns>
		public HtmlDocument ParsePage(string html)
		{
			if (html.IsNullOrEmpty())
				throw new ArgumentNullException("html");

			IHtmlElementsCollection elements = ParseString(html);
			HtmlNodeElement element = (HtmlNodeElement)elements.FirstOrDefault(x => x.TagName == "html");
			HtmlDocument document = new HtmlDocument();
			document.Attributes = element.Attributes;
			document.Children = element.Children;
			document.Text(element.Texts());
			document.Doctype = (HtmlDocTypeElement)elements.FirstOrDefault(x => x.TagName.IsEqualIgnoreCase("!DOCTYPE"));
					
			return document;
		}
		/// <summary>
		/// Try convert html string to IHtmlElementsCollection.
		/// </summary>
		/// <param name="html">Valid html string.</param>
		/// <param name="htmlElements">When the given string is parsed successfully, IHtmlElementsCollection instance represent given html string, otherwise null.</param>
		/// <returns>True, if the given string is parsed successfully, otherwise false.</returns>
		public bool TryParseString(string html, out IHtmlElementsCollection htmlElements) 
		{
			try
			{
				htmlElements = ParseString(html);
				return true;
			}
			catch
			{
				htmlElements = null;
				return false;
			}
		}
		/// <summary>
		/// Convert html string to IHtmlElementsCollection.
		/// </summary>
		/// <param name="html">Valid html string.</param>
		/// <returns cref="IHtmlElementsCollection">IHtmlElementsCollection instance represent given html string.</returns>
		public IHtmlElementsCollection ParseString(string html)
		{
			if(html.IsNullOrEmpty())
				throw new ArgumentNullException("html");

			IHtmlParserManager parserManger = _parserManagerFactory.Create(html);
			return parserManger.Parse();
		}
	}
}
