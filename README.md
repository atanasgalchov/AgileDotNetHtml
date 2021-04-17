# Agile Dot Net Html

## Table of Contents

- [Introduction](#introduction)
- [Getting Started](#getting-started)
- [Authors](#authors)
- [License](#license)

## Introduction

I believe that HtmlAgilityPack is a great library for working whit HTML in C#, but here is a good alternative. Agile Dot Net Html is a library that gives features as parsing and building HTML. Agile Dot Net Html allow you convert HTML to C# objects represent this HTML and Build these object to HTML string again. There is a rich set of C# object which represent HTML elements and their attributes by w3 school HTML 5 standard. The idea of this project is to give you a good alternative on HtmlAgilityPack and allow you fast and easy create and edit composite HTML structures.

## Getting Started

```C#
	HtmlParser parser = new HtmlParser();
	HtmlDocument documnet = parser.ParsePageFromUrl("http://some-patch");
	
	HtmlBuilder builder = new HtmlBuilder();
	IHtmlContent html = builder.CreateHtmlContent(documnet);
```

## Authors

#### Atanas Galchov
* https://github.com/atanasgalchov
* https://www.linkedin.com/in/atanas-galchov-451ba6128/

## License

`AgileDotNetHtml` is open source software [licensed as MIT] https://github.com/atanasgalchov/AgileDotNetHtml/blob/master/LICENSE.

[//]: # (HyperLinks)

[GitHub Repository]: https://github.com/atanasgalchov/AgileDotNetHtml

[GitHub]: https://github.com/atanasgalchov
[LinkedIn]: https://www.linkedin.com/in/atanas-galchov-451ba6128/
