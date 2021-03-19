using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Parser;
using Microsoft.AspNetCore.Html;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AgileDotNetHtml.Test
{
	public class CommonTest
	{
		IHtmlStandarts htmlStandartsMock = new Html5Standarts();
		HtmlParser htmlParser;
		HtmlBuilder htmlBuilder;


        [Theory]
        [InlineData("<div></div>")]
        public void ParseBuild_ReturnHtmlStringAsInput(string html)
        {
            // Arrange          

            htmlBuilder = new HtmlBuilder(htmlStandartsMock);
            htmlParser = new HtmlParser(htmlStandartsMock);

            IHtmlElementsCollection elements = htmlParser.ParseString(html);

            // Act
            IHtmlContent result = htmlBuilder.CreateElement(elements);

            // Assert
            Assert.Equal(html, result.ToString());
        }
    }


}
