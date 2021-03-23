using AgileDotNetHtml.Models;
using Microsoft.AspNetCore.Html;
using Xunit;

namespace AgileDotNetHtml.Test
{
	public class HtmlBuilderTest
    {
        HtmlBuilder htmlBuilder;

        // -- Create --------------------------------------------------------------------------------------------------------------------------------

        [Fact]
        public void Create_ReturnTagAsHtmlString_WhenTagIsEmpty()
        {
            // Arrange          
            htmlBuilder = new HtmlBuilder();

            HtmlElement htmlTag = new HtmlElement("div");

            // Act
            IHtmlContent result = htmlBuilder.CreateHtmlContent(htmlTag);

            // Assert
            Assert.Equal("<div></div>", result.ToString());
        }


        [Fact]
        public void Create_ReturnTagAsHtmlString_WhenTagIsHaveText()
        {
            // Arrange          
            htmlBuilder = new HtmlBuilder();

            HtmlElement htmlTag = new HtmlElement("div", "Text");

            // Act
            IHtmlContent result = htmlBuilder.CreateHtmlContent(htmlTag);

            // Assert
            Assert.Equal("<div>Text</div>", result.ToString());
        }

        [Fact]
        public void Create_ReturnTagAsHtmlString_WhenTagHaveTextAfterChildren()
        {
            // Arrange          
            htmlBuilder = new HtmlBuilder();

            HtmlElement htmlTag = new HtmlElement("div");
            htmlTag.Children.Add(new HtmlElement("span"));
            htmlTag.Text("Text", htmlTag.Children.LastOrDefault().UId);

            // Act
            IHtmlContent result = htmlBuilder.CreateHtmlContent(htmlTag);

            // Assert
            Assert.Equal("<div><span></span>Text</div>", result.ToString());
        }

        [Fact]
        public void Create_ReturnTagAsHtmlString_WhenTagHaveTextBeforeChildren()
        {
            // Arrange          
            htmlBuilder = new HtmlBuilder();

            HtmlElement htmlTag = new HtmlElement("div", "Text");
            htmlTag.Children.Add(new HtmlElement("span"));

            // Act
            IHtmlContent result = htmlBuilder.CreateHtmlContent(htmlTag);

            // Assert
            Assert.Equal("<div>Text<span></span></div>", result.ToString());
        }

        [Fact]
        public void Create_ReturnTagAsHtmlString_WhenTagHaveTextBetweenChildren()
        {
            // Arrange          
            htmlBuilder = new HtmlBuilder();

            HtmlElement htmlTag = new HtmlElement("div");
            HtmlElement span = new HtmlElement("span");
            htmlTag.Children.Add(span);
            htmlTag.Text("Text", span.UId);
            HtmlElement span1 = new HtmlElement("span");
            htmlTag.Children.Add(span1);
            htmlTag.Text("Text1", span1.UId);
            HtmlElement span2 = new HtmlElement("span");
            htmlTag.Children.Add(span2);
            htmlTag.Text("Text2", span2.UId);

            // Act
            IHtmlContent result = htmlBuilder.CreateHtmlContent(htmlTag);

            // Assert
            Assert.Equal("<div><span></span>Text<span></span>Text1<span></span>Text2</div>", result.ToString());
        }
    }
}
