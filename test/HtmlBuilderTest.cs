using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
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
        Mock<IHtmlElement> htmlTagsMock;
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


        // -- IsValidHtmlTag ------------------------------------------------------------------------------------------------------------------------

        [Fact]
        public void IsValidHtmlTag_ReturnTrue_WhenTagExistAndIsWithBrackets()
        {
            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AllTags).Returns(new string[] { "<div>" });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            bool result = htmlBuilder.IsValidHtmlTag("div");

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsValidHtmlTag_ReturnTrue_WhenTagExistAndIsWithoutBrackets()
        {
            // Arrange
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AllTags).Returns(new string[] { "div" });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            bool result = htmlBuilder.IsValidHtmlTag("div");

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsValidHtmlTag_ReturnFalse_WhenTagNotExist()
        {
            // Arrange
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AllTags).Returns(new string[] { "input", "span" });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            bool result = htmlBuilder.IsValidHtmlTag("div");

            // Assert
            Assert.False(result);
        }

        // -- IsSelfClosingHtmlTag ------------------------------------------------------------------------------------------------------------------

        [Fact]
        public void IsSelfClosingHtmlTag_ReturnTrue_WhenTagExistAndIsWithBrackets()
        {
            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.SelfClosingTags).Returns(new string[] { "<input>" });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            bool result = htmlBuilder.IsSelfClosingHtmlTag("input");

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsSelfClosingHtmlTag_ReturnTrue_WhenTagExistAndIsWithBracketsAndSlash()
        {
            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.SelfClosingTags).Returns(new string[] { "<input />" });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            bool result = htmlBuilder.IsSelfClosingHtmlTag("input");

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsSelfClosingHtmlTag_ReturnTrue_WhenTagExistAndIsWithoutBrackets()
        {
            // Arrange
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.SelfClosingTags).Returns(new string[] { "input" });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            bool result = htmlBuilder.IsSelfClosingHtmlTag("input");

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsSelfClosingHtmlTag_ReturnFalse_WhenTagNotExist()
        {
            // Arrange
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.SelfClosingTags).Returns(new string[] { "img", "input" });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            bool result = htmlBuilder.IsSelfClosingHtmlTag("div");

            // Assert
            Assert.False(result);
        }

        // -- TrimHtmlTag ---------------------------------------------------------------------------------------------------------------------------

        [Theory]
        [InlineData("div")]
        [InlineData("div ")]
        [InlineData("<di v>")]
        [InlineData("< div")]
        [InlineData("<div>")]
        [InlineData("<div />")]
        public void TrimHtmlTag_ReturnTrimmedTag_WhenTagHaveBrackets(string tagName)
        {
            // Arrange
            htmlStandartsMock = new Mock<IHtmlStandarts>();

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            string result = htmlBuilder.TrimHtmlTag(tagName);

            // Assert
            Assert.Equal("div", result);
        }

        // -- IsValidHtmlAttribute  -----------------------------------------------------------------------------------------------------------------

        [Fact]
        public void IsValidHtmlAttribute_ReturnTrue_WhenAttributeExist()
        {
            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AttributeTags).Returns(new Dictionary<string, string[]> { { "action", null } });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            bool result = htmlBuilder.IsValidHtmlAttribute("action");

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsValidHtmlAttribute_ReturnFalse_WhenAttributeNotExist()
        {
            // Arrange
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AttributeTags).Returns(new Dictionary<string, string[]> { { "action", null } });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            bool result = htmlBuilder.IsValidHtmlAttribute("src");

            // Assert
            Assert.False(result);
        }

        // -- IsValidHtmlAttributeForTag  -----------------------------------------------------------------------------------------------------------

        [Fact]
        public void IsValidHtmlAttributeForTag_ReturnTrue_WhenAttributeValidForTag()
        {
            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AttributeTags).Returns(new Dictionary<string, string[]> { { "action", new string[] { "form" } } });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            bool result = htmlBuilder.IsValidHtmlAttributeForTag("action", "form");

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsValidHtmlAttributeForTag_ReturnTrue_WhenAttributeValidForTagAndAttributeIsGlobal()
        {
            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AttributeTags).Returns(new Dictionary<string, string[]> { { "id", null } });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            bool result = htmlBuilder.IsValidHtmlAttributeForTag("id", "div");

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsValidHtmlAttributeForTag_ReturnFalse_WhenAttributeNotValidForTag()
        {
            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AttributeTags).Returns(new Dictionary<string, string[]> { { "action", new string[] { "form" } } });

            htmlBuilder = new HtmlBuilder(htmlStandartsMock.Object);

            // Act
            bool result = htmlBuilder.IsValidHtmlAttributeForTag("action", "div");

            // Assert
            Assert.False(result);
        }
    }
}
