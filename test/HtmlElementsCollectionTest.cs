using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AgileDotNetHtml.Test
{
    public class HtmlElementsCollectionTest
    {
        Mock<IHtmlStandarts> htmlStandartsMock;
        HtmlElementsCollection htmlElementsCollection;

        // -- Get --------------------------------------------------------------------------------------------------------------------------------

        [Fact]
        public void Get_ReturnNull_WhenCollectionIsEmpty()
        {

            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AllTags).Returns(new string[] { "<div>" });

            htmlElementsCollection = new HtmlElementsCollection();

            // Act
            IHtmlElement result = htmlElementsCollection.Get("1");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Get_ReturnNull_WhenCollectionIsNotEmptyAndElementNotExist()
        {

            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AllTags).Returns(new string[] { "<div>" });

            htmlElementsCollection = new HtmlElementsCollection() { new HtmlElement("div"), new HtmlElement("div") };

            // Act
            IHtmlElement result = htmlElementsCollection.Get("1");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Get_ReturnNull_WhenCollectionIsNotEmptyAndElementsHaveChildrenAndElementNotExist()
        {

            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AllTags).Returns(new string[] { "<div>" });

            htmlElementsCollection = new HtmlElementsCollection() {
                new HtmlElement("div") {  Children = new HtmlElementsCollection { new HtmlElement("span") } },
                new HtmlElement("div") {  Children = new HtmlElementsCollection { new HtmlElement("span") } }
            };

            // Act
            IHtmlElement result = htmlElementsCollection.Get("1");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Get_ReturnElement_WhenCollectionIsNotEmptyAndAndElementExist()
        {

            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AllTags).Returns(new string[] { "<div>" });

            var searchedElement = new HtmlElement("div") { Children = new HtmlElementsCollection { new HtmlElement("span") } };
            htmlElementsCollection = new HtmlElementsCollection() {
                    searchedElement,
                    new HtmlElement("div") {  Children = new HtmlElementsCollection { new HtmlElement("span") } }
                };

            // Act
            IHtmlElement result = htmlElementsCollection.Get(searchedElement.UId);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Get_ReturnElement_WhenCollectionIsNotEmptyAndAndElementExistDeep()
        {
            // Arrange          
            htmlStandartsMock = new Mock<IHtmlStandarts>();
            htmlStandartsMock.Setup(x => x.AllTags).Returns(new string[] { "<div>" });

            var searchedElement = new HtmlElement("div") { Children = new HtmlElementsCollection { new HtmlElement("span") } };
            htmlElementsCollection = new HtmlElementsCollection() {
                new HtmlElement("div")
                {
                    Children = new HtmlElementsCollection
                    {
                        new HtmlElement("span")
                        {
                            Children = new HtmlElementsCollection
                            {
                                new HtmlElement("span")
                                {
                                    Children = new HtmlElementsCollection { searchedElement }
                                }
                            }
                        }
                    }
                },
                new HtmlElement("div")
                {
                    Children = new HtmlElementsCollection { new HtmlElement("span") }
                }
            };

            // Act
            IHtmlElement result = htmlElementsCollection.Get(searchedElement.UId);

            // Assert
            Assert.NotNull(result);
        }
    }
}
