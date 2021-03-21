using AgileDotNetHtml.Interfaces;
using Xunit;

namespace AgileDotNetHtml.Test
{
	public class HtmlParserTest
	{
        HtmlParser htmlParser = new HtmlParser();

        // -- ParseString --------------------------------------------------------------------------------------------------------------------------------

        [Theory]
        [InlineData("<div></div>")]
        [InlineData("<input />")]
        [InlineData("<div><span></span></div>")]
        [InlineData("<div><span><span></span></span></div>")]
        [InlineData("<div><input /><input /></div>")]
        [InlineData("<div><input /><span><input /></span></div>")]
        public void ParseString_ReturnOneElementInCollection_WhenStringContainsOneTag(string html)
        {
            // Arrange          

            // Act
            IHtmlElementsCollection elements = htmlParser.ParseString(html);

            // Assert
            Assert.Single(elements.ToList());
        }
        [Theory]
        [InlineData("<div>Text</div>")]
        public void ParseString_ReturnElementWithText_WhenTagHaveTextWhitoutChildren(string html)
        {
            // Arrange          

            // Act
            IHtmlElement element = htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.Equal("Text", element.Text().ToString());
        }
        [Theory]
        [InlineData("<div>Text<span><span></span></span><span></span></div>")]
        public void ParseString_ReturnElementWithText_WhenTextIsBeforeChildren(string html)
        {
            // Arrange          

            // Act
            IHtmlElement element = htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.Equal("Text", element.Text().ToString());
            Assert.Equal(0, element.TextIndex);
        }
        [Theory]
        [InlineData("<div><span></span><div></div><span></span><div></div><span></span><div></div>Text</div>")]
        public void ParseString_ReturnElementWithText_WhenTextIsAfterChildren(string html)
        {
            // Arrange          

            // Act
            IHtmlElement element = htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.Equal("Text", element.Text().ToString());
            Assert.Equal(6, element.TextIndex);
        }
        [Theory]
        [InlineData("<div><span></span>Text<span></span></div>")]
        public void ParseString_ReturnElementWithText_WhenTextIsBetweenChildren(string html)
        {
            // Arrange          

            // Act
            IHtmlElement element = htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.Equal("Text", element.Text().ToString());
            Assert.Equal(1, element.TextIndex);
        }
    }
}
