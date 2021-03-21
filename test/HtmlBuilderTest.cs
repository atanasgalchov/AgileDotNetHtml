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
    }
}
