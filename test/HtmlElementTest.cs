using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using AgileDotNetHtml.Models.HtmlElements;
using Xunit;

namespace AgileDotNetHtml.Test
{
	public class HtmlElementTest
	{
        [Fact]
        public void Append_ShouldAppendChildAndSetHimParrent()
        {

            // Arrange          
            HtmlNodeElement element = new HtmlNodeElement("div");

            // Act
            element.Append(new HtmlNodeElement("div"));

            // Assert
            Assert.NotNull(element.Children);
            Assert.NotEmpty(element.Children);
            Assert.Equal(element.UId, element.Children.FirstOrDefault().Parents.FirstOrDefault().UId);
        }
        [Fact]
        public void AppendRange_ShouldAppendChilrendAndSetHimParrent_WhenAppendSomeChildren()
        {

            // Arrange          
            HtmlNodeElement element = new HtmlNodeElement("div");
            HtmlElementsCollection htmlElementsCollection = new HtmlElementsCollection();
            htmlElementsCollection.Add(new HtmlDivElement());
            htmlElementsCollection.Add(new HtmlSpanElement());
            htmlElementsCollection.Add(new HtmlInputElement());
            htmlElementsCollection.Add(new HtmlPElement());
            htmlElementsCollection.Add(new HtmlH1Element());
            htmlElementsCollection.Add(new HtmlH2Element());

            // Act
            element.AppendRange(htmlElementsCollection);

            // Assert
            Assert.NotNull(element.Children);
            Assert.NotEmpty(element.Children);
            Assert.False(htmlElementsCollection.Any(x => x.Parents.FirstOrDefault().UId != element.UId));
        }
    }
}
