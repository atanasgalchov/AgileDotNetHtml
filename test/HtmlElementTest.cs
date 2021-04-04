using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using Xunit;

namespace AgileDotNetHtml.Test
{
	public class HtmlElementTest
	{
        [Fact]
        public void Append_ShouldAppendChildAndSetHimParrent()
        {

            // Arrange          
            HtmlElement element = new HtmlElement("div");

            // Act
            element.Append(new HtmlElement("div"));

            // Assert
            Assert.NotNull(element.Children);
            Assert.NotEmpty(element.Children);
            Assert.Equal(element.UId, element.Children.FirstOrDefault().Parents.FirstOrDefault().UId);
        }
        [Fact]
        public void AppendRange_ShouldAppendChilrendAndSetHimParrent_WhenAppendSomeChildren()
        {

            // Arrange          
            HtmlElement element = new HtmlElement("div");
            HtmlElementsCollection htmlElementsCollection = new HtmlElementsCollection();
            htmlElementsCollection.Add(new HtmlElement("div"));
            htmlElementsCollection.Add(new HtmlElement("span"));
            htmlElementsCollection.Add(new HtmlElement("input"));
            htmlElementsCollection.Add(new HtmlElement("p"));
            htmlElementsCollection.Add(new HtmlElement("h1"));
            htmlElementsCollection.Add(new HtmlElement("h2"));

            // Act
            element.AppendRange(htmlElementsCollection);

            // Assert
            Assert.NotNull(element.Children);
            Assert.NotEmpty(element.Children);
            Assert.False(htmlElementsCollection.Any(x => x.Parents.FirstOrDefault().UId != element.UId));
        }
    }
}
