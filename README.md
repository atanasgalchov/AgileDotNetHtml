# Agile Dot Net Html

## Table of Contents

- [Introduction](#introduction)
- [Getting Started](#getting-started)
- [Authors](#authors)
- [License](#license)

## Introduction

I believe that have many great libraries for working whit HTML in C#, but here is a good alternative. AgileDotNetHtml is a library that gives features as parsing and building HTML. The library allow you convert HTML to C# objects represent this HTML and Build these object to HTML string again. There is a rich set of C# object which represent HTML elements and their attributes by w3 school HTML 5 standard. The idea of this project is to allow you fast and easy create and edit composite HTML structures.

## Getting Started

### Parse Page
* Load and parse page from specific url.

```C#
	HtmlParser parser = new HtmlParser();
	HtmlDocument documnet = parser.ParsePageFromUrl("http://some-patch");
	
	HtmlBuilder builder = new HtmlBuilder();
	IHtmlContent html = builder.CreateHtmlContent(documnet);
```

### Parse String
* Parse specific HTML string

```C#
	string htmlString = "<div class='some element'><ul class='ul'><li></li><li></li></ul></div>";
	HtmlParser parser = new HtmlParser();		
	IHtmlElementsCollection elements =  parser.ParseString(htmlString);
	IHtmlElementsCollection liElements = elements.FindAll(x => x.TagName == "li");

	HtmlBuilder builder = new HtmlBuilder();
	IHtmlContent htmlContent = builder.CreateHtmlContent(liElements);
```


## Authors

#### Atanas Galchov
* https://github.com/atanasgalchov
* https://www.linkedin.com/in/atanas-galchov-451ba6128/


## License

`AgileDotNetHtml` is open source software licensed as MIT

[//]: # (HyperLinks)

[LICENSE]: https://github.com/atanasgalchov/AgileDotNetHtml/blob/master/LICENSE
[GitHub]: https://github.com/atanasgalchov
[LinkedIn]: https://www.linkedin.com/in/atanas-galchov-451ba6128/
