using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using Xunit;

namespace AgileDotNetHtml.Test
{
	public class HtmlElementsCollectionTest
    {
        HtmlElementsCollection htmlElementsCollection;

        // -- Get --------------------------------------------------------------------------------------------------------------------------------

        [Fact]
        public void Get_ReturnNull_WhenCollectionIsEmpty()
        {

            // Arrange          

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
