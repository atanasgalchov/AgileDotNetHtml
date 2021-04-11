using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using AgileDotNetHtml.Models.HtmlElements;
using Moq;
using Moq.Protected;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AgileDotNetHtml.Test
{
	public class HtmlParserTest
	{
        HtmlParser htmlParser = new HtmlParser();

        // -- ParsePage --------------------------------------------------------------------------------------------------------------------------------

        [Fact]
        public void ParsePage_ReturnEmptyDocument_WhenLoadSuccessfullyAndResponseContentIsEmpty()
        {
            // Arrange          
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("<!DOCTYPE><html></html>"),
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            mockFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);
           
            htmlParser = new HtmlParser(mockFactory.Object);

            // Act
            HtmlDocument document = htmlParser.ParsePageFromUrl("http://test/test");

            // Assert
            Assert.NotNull(document);
        }
        [Theory]
        [InlineData("<!DOCTYPE html><html><head><title></title></head><body></body></html>")]
        public void ParsePage_ReturnEmptyDocument_WhenLoadSuccessfullyAndResponseHaveSimpleHtmlSctructure(string html)
        {
            // Arrange          
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(html),
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            mockFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);

            htmlParser = new HtmlParser(mockFactory.Object);

            // Act
            HtmlDocument document = htmlParser.ParsePageFromUrl("http://test/test");

            // Assert
            Assert.NotNull(document);
            Assert.NotNull(document.Head);
            Assert.NotNull(document.Title);
            Assert.NotNull(document.Body);
        }

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
            HtmlNodeElement element = (HtmlNodeElement)htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.NotEmpty(element.Texts());
            Assert.Equal("Text", element.Texts()[0].HtmlString.Value);
            Assert.Null(element.Texts()[0].AfterElementUId);
        }
        [Theory]
        [InlineData("<div>Text<span><span></span></span><span></span></div>")]
        public void ParseString_ReturnElementWithText_WhenHaveTextBeforeChildren(string html)
        {
            // Arrange          

            // Act
            HtmlNodeElement element = (HtmlNodeElement)htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.NotEmpty(element.Texts());
            Assert.Equal("Text", element.Texts()[0].HtmlString.Value);
            Assert.Null(element.Texts()[0].AfterElementUId);
        }
        [Theory]
        [InlineData("<div><span></span><div></div><span></span><div></div><span></span><div></div>Text</div>")]
        public void ParseString_ReturnElementWithText_WhenHaveTextAfterChildren(string html)
        {
            // Arrange          

            // Act
            HtmlNodeElement element = (HtmlNodeElement)htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.Single(element.Texts());
            Assert.Equal("Text", element.Texts()[0].HtmlString.Value);
            Assert.Equal(element.Children.LastOrDefault().UId, element.Texts()[0].AfterElementUId);
        }
        [Theory]
        [InlineData("<div>Text<span><p>1</p></span>Text1<span>1</span>Text2</div>")]
        public void ParseString_ReturnElementWithText_WhenHaveTextBetweenChildren(string html)
        {
            // Arrange          

            // Act
            HtmlNodeElement element = (HtmlNodeElement)htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.Equal(3, element.Texts().Length);
            Assert.Equal("Text", element.Texts()[0].HtmlString.Value);
            Assert.Equal("Text1", element.Texts()[1].HtmlString.Value);
            Assert.Equal("Text2", element.Texts()[2].HtmlString.Value);
        }

        [Theory]
        [InlineData("<script>function myFunction() { var $template = \"<button type=\"button\" onclick=\"myFunction()\">Try it</button>\" var $div = $(<div>); $div.append('<span />');  document.getElementById(\"demo\").innerHTML = \"Paragraph changed.\"; }</script>")]
        public void ParseString_ReturnScriptElement_WhenHaveJavaScript(string html)
        {
            // Arrange          

            // Act
            HtmlPairTagsElement element = (HtmlPairTagsElement)htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.NotNull(element);
            Assert.Equal("function myFunction() { var $template = \"<button type=\"button\" onclick=\"myFunction()\">Try it</button>\" var $div = $(<div>); $div.append('<span />');  document.getElementById(\"demo\").innerHTML = \"Paragraph changed.\"; }", element.Text().ToString());
        }
        [Theory]
        [InlineData("<div id=\"1234\" class=\"test\"></div>")]
        public void ParseString_ReturnOneElementWhitSimpleKeyValueAttributes(string html)
        {
            // Arrange          

            // Act
            IHtmlElement element = htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.Equal(2, element.Attributes.Length);
            Assert.Equal("id", element.Attributes[0].Name);
            Assert.Equal("1234", element.Attributes[0].Value);
            Assert.Equal("class", element.Attributes[1].Name);
            Assert.Equal("test", element.Attributes[1].Value);

        }
        [Theory]
        [InlineData("<input checked disabled hidden />")]
        public void ParseBuild_ParseAndReturnOneElementWhitKeyWhitoutValueAttributes(string html)
        {
            // Arrange          

            // Act
            IHtmlElement element = htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.Equal(3, element.Attributes.Length);
            Assert.Equal("checked", element.Attributes[0].Name);
            Assert.Null(element.Attributes[0].Value);
            Assert.Equal("disabled", element.Attributes[1].Name);
            Assert.Null(element.Attributes[1].Value);
            Assert.Equal("hidden", element.Attributes[2].Name);
            Assert.Null(element.Attributes[2].Value);
        }
        [Theory]
        [InlineData("<div id='1234' hidden class=\"test test t-test test-t\" checked type = ' text '></div>")]
        public void ParseBuild_ParseAndReturnOneElementWhitKeyValueAndKeyWhitoutValueAttributes(string html)
        {
            // Arrange          

            // Act
            IHtmlElement element = htmlParser.ParseString(html).FirstOrDefault();

            // Assert
            Assert.Equal(5, element.Attributes.Length);
            Assert.Equal("id", element.Attributes[0].Name);
            Assert.Equal("1234", element.Attributes[0].Value);
            Assert.Equal("hidden", element.Attributes[1].Name);
            Assert.Null(element.Attributes[1].Value);
            Assert.Equal("class", element.Attributes[2].Name);
            Assert.Equal("test test t-test test-t", element.Attributes[2].Value);           
            Assert.Equal("checked", element.Attributes[3].Name);
            Assert.Null(element.Attributes[3].Value);
            Assert.Equal("type", element.Attributes[4].Name);
            Assert.Equal("text", element.Attributes[4].Value);
        }
    }
}
