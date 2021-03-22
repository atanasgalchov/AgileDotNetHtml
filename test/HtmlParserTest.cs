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
            Assert.NotEmpty(element.Texts());
            Assert.Equal("Text", element.Texts()[0].HtmlString.Value);
            Assert.Equal(0, element.Texts()[0].Index);
        }
        [Theory]
        [InlineData("<div>Text<span><span></span></span><span></span></div>")]
        public void ParseString_ReturnElementWithText_WhenHaveTextBeforeChildren(string html)
        {
            // Arrange          

            // Act
            IHtmlElement element = htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.NotEmpty(element.Texts());
            Assert.Equal("Text", element.Texts()[0].HtmlString.Value);
            Assert.Equal(0, element.Texts()[0].Index);
        }
        [Theory]
        [InlineData("<div><span></span><div></div><span></span><div></div><span></span><div></div>Text</div>")]
        public void ParseString_ReturnElementWithText_WhenHaveTextAfterChildren(string html)
        {
            // Arrange          

            // Act
            IHtmlElement element = htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.NotEmpty(element.Texts());
            Assert.Equal("Text", element.Texts()[0].HtmlString.Value);
            Assert.Equal(6, element.Texts()[0].Index);
        }
        [Theory]
        [InlineData("<div>Text<span></span>Text<span>1</span>Text</div>")]
        public void ParseString_ReturnElementWithText_WhenHaveTextBetweenChildren(string html)
        {
            // Arrange          

            // Act
            IHtmlElement element = htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.NotEmpty(element.Texts());
            Assert.Equal("Text", element.Texts()[0].HtmlString.Value);
            Assert.Equal(1, element.Texts()[0].Index);
        }
    }
}
