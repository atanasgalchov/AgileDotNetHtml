using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using AgileDotNetHtml.Models.HtmlElements;
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

            htmlElementsCollection = new HtmlElementsCollection() { new HtmlPairTagsElement("div"), new HtmlPairTagsElement("div") };

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
                new HtmlNodeElement("div") {  Children = new HtmlElementsCollection { new HtmlNodeElement("span") } },
                new HtmlNodeElement("div") {  Children = new HtmlElementsCollection { new HtmlNodeElement("span") } }
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

            var searchedElement = new HtmlNodeElement("div") { Children = new HtmlElementsCollection { new HtmlNodeElement("span") } };
            htmlElementsCollection = new HtmlElementsCollection() {
                    searchedElement,
                    new HtmlNodeElement("div") {  Children = new HtmlElementsCollection { new HtmlNodeElement("span") } }
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

            var searchedElement = new HtmlNodeElement("div") { Children = new HtmlElementsCollection { new HtmlNodeElement("span") } };
            htmlElementsCollection = new HtmlElementsCollection() {
                new HtmlNodeElement("div")
                {
                    Children = new HtmlElementsCollection
                    {
                        new HtmlNodeElement("span")
                        {
                            Children = new HtmlElementsCollection
                            {
                                new HtmlNodeElement("span")
                                {
                                    Children = new HtmlElementsCollection { searchedElement }
                                }
                            }
                        }
                    }
                },
                new HtmlNodeElement("div")
                {
                    Children = new HtmlElementsCollection { new HtmlNodeElement("span") }
                }
            };

            // Act
            IHtmlElement result = htmlElementsCollection.Get(searchedElement.UId);

            // Assert
            Assert.NotNull(result);
        }
    }
}
