> ***"You should name a variable using the same care with which you name a first-born child."***

Robert C. Martin

---

C# Developer Guidelines (C# Coding Conventions)

* Introduction
* Class Structure
* Naming Conventions
	* Naming Conventions
	* Classes
	* Fields
	* Constructor Parameters
	* Events
	* Properties
	* Methods
	* Method Parameters
* Documenting Code
	* Constructor
	* peroperties
	* Methods
	* Fields and Constants
	* Events
	
# Introduction

The Developer Guidelines are like a railing that helps you to prevent falls in the precipice. Imagine that you walk by the precipice and you made wrong step, if don't have a railing you will fall in the precipice, but if have a railing you can catch and still walk. Here have a stable railing to help us to walk save, namely write clean, readable, and maintainable code.
The objective of this document is to outline a set of language-level programming conventions and development guidelines to add developers to writing high-quality code. The rules below are some of the best practices approved by a lot of experienced developers. Choosing these rules is a result of years of education and professional experience with software development. Keeping the rules below is a warranty for write-on readable and easy maintenance code, and warranty to avoid confusion in the future.
These guidelines used are the same ones in Framework Design Guideline by Microsoft and are:

* ✔️ DO: Do follow this guideline and don’t stray from it
* ❌ DO NOT: Do not violate this guideline
* ⁉️  AVOID a situation at all costs unless there is no other alternative
* ❓ CONSIDER: Consider this guideline and use it when possible, but otherwise it is not strictly necessaary
CONSIDER: This document’s conventions and guidelines are only as effective as its adoption rate by developers.
CONSIDER: It is highly recommended that you use this developer document in conjunction with the official Framework Design Guidelines, Conventions, Idioms, and Patterns for Reusable .NET libraries, and Code Complete 2, A practical handbook of software construction, both of which are high quality resources for engineering great software.

# Class Structure

By structuring your code in this manner your code serves as a sort of index that can be easily read and navigated. For optimal class layout and maintainability, use the following structure.

```C#
// Using directives 
// Global Delegates 
	
// Copyright information 
namespace (<CompanyName>|<ProjectName>).Technology.Feature
{ 
    class ClassName 
    { 
        // 1. Fields, Constants
        //    - private
        //    - private protected
        //    - protected internal
        //    - protected        
        //    - internal
        //    - public
        // 2. Constructors
        // 3. Events
        // 4. Properties
        // 5. Methods
        // 6. Nested Types
    } 
}
```

* ✔️ DO: Use this class structure consistently in all classes you write.
* ✔️ DO: Declare using directives in alphabetical order. Use the Organize Usings > Remove and Sort command in Visual Studio to easily maintain using directives.
* ✔️ DO: Write copyright comments or important informational notices about the current source code file.
* ✔️ DO: Declare fields, readonly fields, static fields, or constants at the beginning of the class definition by group, and ordered by protection level (start with private) then by alphabetical.
* ✔️ DO: Declare constructors in order of complexity (number of parameters), beginning with the least complex to the most complex.
* ✔️ DO: Declare events ordered by protection level then by alphabetical.
* ✔️ DO: Declare properties ordered by protection level (start with private) then by alphabetical.
* ✔️ DO: Declare methods ordered by protection level (start with private) then by alphabetical. When declaring polymorphic methods, declare them in order of complexity (number of parameters), beginning with the least complex to the most complex.
* ✔️ DO: Declare nested types ordered by protection level (start with private) then by alphabetical.
* ✔️ DO: Separate diferent member types fields, properties, methods, events, delegates and other with one empty row.
* ✔️ DO: Declare only one type per file, and name the file after the type. When declaring type ClassName also rename the source code file to ClassName.cs.
* ❌ DO NOT: Leave empty rows inside members type group.
* ❌ DO NOT: Leave empty rows more than one.

:information_source: *Why: Using the same class structure allows you to find easy, things which you looking for regardless of when and who is wrote the code.*

# Naming Conventions

Be forewarned, there is extreme bias that lies in the coming text, but its bias that is correct and that’s all you need to know. Now that we have that settled; naming conventions are one of the most large and controversial discussions to have among developers, but to put it simple terms: there are far too many just plain bad conventions out there. I have seen conventions that are awkward, decent, or just completely horrid. If there is one thing that I do know from all that experience, it’s that Microsoft has it right.

Writing code is an art in of itself, and it’s pretty much identical to writing any kind of document. The analogy I like to use is that it is like writing a high quality essay. You either write a quality essay or you don’t. If you don’t, you get a D for a grade, or worse, an F. If you have read or written C++, you know just how cryptic some of the names for things are, and C++ and its vast libraries aren’t even the worst culprits out there. Unfortunately for some languages like C++ they are just dated (but don’t confuse that with deprecated) and they carry a lot of baggage, including poor naming conventions. C++ has improved and keeps improving though, but other languages, libraries and frameworks have carried that bad baggage and kept it.

This section will be similar to the previous section on documentation, because the way you name things will greatly affect how your code is both read and interpreted not just by you, but by others. In addition, when there is no documentation, all you have is code for your documentation, so it better be good, and that’s the goal. High quality code. I’m going to break naming conventions up into logical groups. We will start with namespaces, then move to classes and their implementation including fields, properties, events, methods, and member variables within methods.

