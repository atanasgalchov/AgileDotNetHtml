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
	HtmlDocument documnet = parser.ParsePageFromUrl(path);
```

### Parse String
* Parse specific HTML string

```C#
	string htmlString = "<div class='some element'><ul class='ul'><li></li><li></li></ul></div>";
	HtmlParser parser = new HtmlParser();		
	IHtmlElementsCollection elements =  parser.ParseString(htmlString);
```

### Build Html Content
* Create HTML content containing form elements whit different kinds of inputs.

```C#
	HtmlFormElement formElement = new HtmlFormElement();
				
	HtmlInputElement textInput = new HtmlInputElement("text");
	textInput.Name = "TextInput";
	textInput.Value = "Some value";
				
	HtmlInputElement radioInput = new HtmlInputElement("radio");
	radioInput.Name = "RadioInput";
	radioInput.Value = "Some value";

	HtmlTextareaElement textArea = new HtmlTextareaElement();
	textArea.Name = "TextArea";
	textArea.Text("Some text...");

	formElement.Append(radioInput);
	formElement.Append(textInput);
	formElement.Append(textArea);

	HtmlBuilder builder = new HtmlBuilder();
	IHtmlContent formHtmlContent = builder.CreateHtmlContent(formElement);
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
