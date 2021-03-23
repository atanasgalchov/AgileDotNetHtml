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
        public void ParseBuild_ParseAndReturnOneElement(string html)
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

        [Theory]
        [InlineData("<div class=\"test\" style=\"color:Blue;font-size:25px;background-image: url(\"https://www.text.test/test/test/test/test2x/test.png\");content:('ss.png')\" 'disabled'='disabled' \"checked\"=\"checked\" data-role='test-element' onclick=\"function(){ if($(this).attr('data-value')) { $(this).text(\"Text\") } }\" src=\"/external/images/logo-lrg.png?version=5.0.155\" data-val=\"\" data-val-required=\"\"></div>")]
        public void ParseBuild_ParseAndReturnOneElementWhitKeyValueAttributes(string html)
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
