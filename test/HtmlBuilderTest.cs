using AgileDotNetHtml.Interfaces;
using Microsoft.AspNetCore.Html;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AgileDotNetHtml.Test
{
    public class HtmlBuilderTest
    {
        Mock<IHtmlStandarts> htmlStandartsMock;
        HtmlBuilder htmlBuilder;

        // -- Create --------------------------------------------------------------------------------------------------------------------------------

        [Fact]
        public void Create_ReturnTagAsHtmlString_WhenTagIsEmpty()
        {
            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AllTags).Returns(new string[] { "<div>" });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            HtmlElement htmlTag = new HtmlElement("div");

            // Act
            IHtmlContent result = htmlBuilder.CreateElement(htmlTag);

            // Assert
            Assert.Equal("<div></div>", result.ToString());
        }
    }
}
