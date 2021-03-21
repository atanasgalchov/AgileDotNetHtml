using AgileDotNetHtml.Interfaces;
using Microsoft.AspNetCore.Html;
using Xunit;

namespace AgileDotNetHtml.Test
{
	public class CommonTest
	{
		HtmlParser htmlParser;
		HtmlBuilder htmlBuilder;

        [Theory]
        [InlineData("<div></div>")]
        public void ParseBuild_ReturnHtmlStringAsInput(string html)
        {
            // Arrange          

            htmlBuilder = new HtmlBuilder();
            htmlParser = new HtmlParser();

            IHtmlElementsCollection elements = htmlParser.ParseString(html);

            // Act
            IHtmlContent result = htmlBuilder.CreateHtmlContent(elements);

            // Assert
            Assert.Equal(html, result.ToString());
        }
    }
}
