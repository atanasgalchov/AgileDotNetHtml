using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Parser;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AgileDotNetHtml.Test
{
	public class HtmlParserTest
	{
        IHtmlStandarts htmlStandartsMock  = new Html5Standarts();
        HtmlParser htmlParser;

        // -- ParseString --------------------------------------------------------------------------------------------------------------------------------

        [Theory]
        [InlineData("<div></div>")]
        [InlineData("<div><span></span></div>")]
        [InlineData("<div><span><span></span></span></div>")]
        [InlineData("<div><input /><input /></div>")]
        [InlineData("<div><input /><span><input /></span></div>")]
        public void ParseString_ReturnOneElementInCollection_WhenStringContainsOneTag(string html)
        {
            // Arrange          

            htmlParser = new HtmlParser(htmlStandartsMock);

            // Act
            IHtmlElementsCollection elements = htmlParser.ParseString(html);

            // Assert
            Assert.Single(elements.ToList());
        }
    }
}
