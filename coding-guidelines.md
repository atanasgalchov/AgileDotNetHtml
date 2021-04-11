> ***"You should name a variable using the same care with which you name a first-born child."***

Robert C. Martin

---

C# Developer Guidelines (C# Coding Conventions)

* [Introduction](#Introduction)
* [Class Structure](#class-structure)
* [Naming Conventions](#naming-conventions)
	* [Naming Namespaces](#naming-namespaces)
	* [Naming Classes](#naming-classes)
	* [Naming Fields](#naming-fields)	
	* [Naming Properties](#naming-properties)
	* [Naming Events](#naming-events)
	* [Naming Methods](#naming-methods)
	* [Naming Constructor Parameters](#naming-constructor-parameters)
	* [Naming Method Parameters](#naming-method-parameters)
* [Documenting Code](#documenting-code)
	* [Documenting Classes](#documenting-classes)
	* [Documenting Constructors](#documenting-constructors)
	* [Documenting Events](#documenting-events)
	* [Documenting Properties](#documenting-properties)
	* [Documenting Methods](#documenting-methods)
	
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
* ✔️ DO: Declare fields, readonly fields, static fields, or constants at the beginning of the class definition by group, and ordered by protection level (beginning with private).
* ✔️ DO: Declare constructors in order of complexity (number of parameters), beginning with the least complex to the most complex.
* ✔️ DO: Declare events ordered by protection level.
* ✔️ DO: Declare properties ordered by protection level (beginning with private).
* ✔️ DO: Declare methods ordered by protection level (beginning with private). When declaring polymorphic methods, declare them in order of complexity (number of parameters), beginning with the least complex to the most complex.
* ✔️ DO: Declare nested types ordered by protection level (beginning with private).
* ✔️ DO: Separate diferent member types fields, properties, methods, events, delegates and other with one empty row.
* ✔️ DO: Declare only one type per file, and name the file after the type. When declaring type ClassName also rename the source code file to ClassName.cs.
* ❌ DO NOT: Leave empty rows inside members type group.
* ❌ DO NOT: Leave empty rows more than one.

:information_source: *Hint: Using the same class structure allows you to find easy, things which you looking for regardless of when and who is wrote the code.*

# Naming Conventions

Be forewarned, there is extreme bias that lies in the coming text, but its bias that is correct and that’s all you need to know. Now that we have that settled; naming conventions are one of the most large and controversial discussions to have among developers, but to put it simple terms: there are far too many just plain bad conventions out there. I have seen conventions that are awkward, decent, or just completely horrid. If there is one thing that I do know from all that experience, it’s that Microsoft has it right.

Writing code is an art in of itself, and it’s pretty much identical to writing any kind of document. The analogy I like to use is that it is like writing a high quality essay. You either write a quality essay or you don’t. If you don’t, you get a D for a grade, or worse, an F. If you have read or written C++, you know just how cryptic some of the names for things are, and C++ and its vast libraries aren’t even the worst culprits out there. Unfortunately for some languages like C++ they are just dated (but don’t confuse that with deprecated) and they carry a lot of baggage, including poor naming conventions. C++ has improved and keeps improving though, but other languages, libraries and frameworks have carried that bad baggage and kept it.

This section will be similar to the previous section on documentation, because the way you name things will greatly affect how your code is both read and interpreted not just by you, but by others. In addition, when there is no documentation, all you have is code for your documentation, so it better be good, and that’s the goal. High quality code. I’m going to break naming conventions up into logical groups. We will start with namespaces, then move to classes and their implementation including fields, properties, events, methods, and member variables within methods.

# Naming Namespaces

The following rules outline the guidelines for naming namespaces.
* ✔️ DO: Use Pascal case.
* ✔️ DO: Use a noun or noun phrase to name a namespace.
* ✔️ DO: Use a well-established company or brand name for the root namespace.
* ✔️ DO: Use a well-established technology name for the second level hierarchical namespace.
* ✔️ DO: Use plural names if it is semantically appropriate.
* ❌ DO NOT: Use the same name for a namespace and a class.
* ❌ DO NOT: Use the underscore character

```C#
namespace DCOMEngineering.Windows.Deployment
{
}
```
:information_source: Hint: Most of the time when naming a namespace I tend to use a brand name for the root instead of my company name. This allows me to reserve my company name for the future of any absolutely critical namespaces. In return I don’t have to do any major refactoring due to namespace collisions because of poor decision making early on. I think it is very important to give your namespace names some serious short-term and long-term thought before you call it set in stone.

# Naming Classes

The following rules outline the guidelines for naming classes.
* ✔️ DO: Use Pascal case.
* ✔️ DO: Use a noun or noun phrase to name a class.
* ✔️ DO: Use a compound word to name a derived class. The second part of the derived class’s name should be the name of the base class, such as InvalidOperationException is an appropriate name for a class derived from Exception.
* ❌ DO NOT: Use a prefix such as C or a suffix such as Class in the class name.
* ❌ DO NOT: Use the prefix I unless the class is an interface.
* ❌ DO NOT: Use the underscore character.

```C#
public class OperationsManager : Manager 
{ 
}
```

:information_source: Hint: Naming a class can be pretty difficult. Just like namespaces, give your classes some serious shortterm and long-term thought. Classes are more likely to encounter name collisions than namespaces, which in the event it does happen can be remedied by using namespaces and namespace aliases, but it’s best to avoid it, if at all possible. There are also exceptions to the conventions for naming a derived class, such as in the example of OperationsManager deriving from Manager. In the business world, both are an employee, so the convention is broken when your Manager class derives from the Employee class. In this situation, that’s okay, but don’t let this stray you from following convention.

# Naming Fields

The following rules outline the guidelines for naming fields.
* ✔️ DO: Use Camel case.
* ✔️ DO: Use descriptive field names preferring a noun or noun phrase. Field names should be descriptive enough that the name of the field and its type can be used to determine its meaning in most scenarios.
* ✔️ DO: Use names that describe the fields meaning rather than names that describe the field’s type.
* ✔️ DO: Use leading underscore for private fields.
* ❌ DO NOT: Use reserved names as field names.
* ❌ DO NOT: Use Hungarian type notation.
* ❓ CONSIDER: Choosing a different name for a field if the current name is too long, and cannot be shortened without sacrificing the ability to easily identify the fields meaning.

```C#
public class OperationsManager : Manager 
{ 
    private Department _department;
    private ICollection<Manager> _managers;
    private decimal _salary;  
    private SiteDirector _siteDirector; 
}
```

# Naming Properties

The following rules outline the guidelines for naming properties.
* ✔️ DO: Use Pascal case.
* ✔️ DO: Use a noun or noun phrase to name properties.
* ❌ DO NOT: Use Hungarian notation.
* ❓ CONSIDER: Naming the property the same as its underlying type when its meaning is literal. For example, if you declare a property named Color, the type of the property should likewise be Color.

```C#
public class OperationsManager : Manager 
{ 
    public String Email { get; set; }
    public SiteDirector SiteDirector { get;set; } 
}
```

# Naming Events

The following rules outline the guidelines for naming events.
* ✔️ DO: Use Pascal case.
* ✔️ DO: Use a verb in the event name to describe the action the event represents, such as Changed in ProgressChanged or Clicked.
* ✔️ DO: Use a gerund (the “ing” form of a verb) if possible to create an event name that expresses the concept of pre and post-events such as in ProgressChanging and ProgressChanged.
* ❌ DO NOT: Prefix an event with On or suffix an event with Event.

```C#
public class CustomerService 
{
     public event EventHandler CustomerCalling;
     public event EventHandler CustomerCalled; 
}
```

:information_source: Hint: Events are another construct that can be hard to name. I remember countless times when I was learning Windows Forms years ago where I would get confused about the order in which events fired. A case that comes to mind is a lot of the controls have both Resized and SizeChanged events. Without documentation it can be hard to deduce which one fires first without debugging it, and what if the order in which they fire could change? This is why it is important to name your events well and document them like we discussed in the previous sections.
It’s also worth noting that it can be hard to name events with pre-event and post-event in mind. Take the example in Figure 4. CustomerCalling is not actually a pre-event, it’s a current event, because you can’t technically know the exact time before a customer calls, until they call. It is a pre-event in the sense that it is a notification you can handle before the action of calling is allowed to continue, but is definitely something to keep in mind when naming an event, because how you name the event may be drastically different depending on the action. You can have an action where you can control when it is invoked, like calling method you know when pre-event takes place, but when you have an event you don’t control like an incoming request, the pre-event isn’t exactly known. For situations like I just stated you need to make sure your events are well-documented on how and when they are triggered so they can be properly consumed by developers.

# Naming Methods
The following rules outline the guidelines for naming methods.
* ✔️ DO: Use Pascal case.
* ✔️ DO: Use verbs or verb phrases to name methods.
* ✔️ DO: Use precise method names that easily describe the action the method performs.
* ❓ CONSIDER: If a method is hard to name because it does more than one thing, it is usually a clear indication that your method needs refactored into multiple methods.

```C#
public class OperationsManager : Manager 
{ 
    public void FireEmployee(Employee employee) 
    { 
    }   
    public Report GetEmployeeReport(Employee employee)
    { 
    }
    public void HirePerson(Person person)
    { 
    } 
}
```

:information_source: Hint: I don’t find methods particularly hard to name, but I do spend a lot of time naming them. Method names are one of the most important, if not the most important identifier to name. They are your implementation details of your class, and where you will spend the majority of your time in code. Name these well enough, and maintaining your code is a lot easier for everyone.

# Naming Constructor Parameters

The following rules outline the guidelines for naming parameters.
* ✔️ DO: Use Camel case.
* ✔️ DO: For parameters that are used for set on private fields use the same name as fields and skip underscore prefix.
* ✔️ DO: Use descriptive parameter names preferring a noun or noun phrase. Parameter names should be descriptive enough that the name of the parameter and its type can be used to determine its meaning in most scenarios.
* ❌ DO NOT: Use reserved parameters.
* ❌ DO NOT: Use Hungarian notation.

```C#
public class Employee
{ 
    private string _name;
    private string _age;
    public Employee(string name, string age)
    {
    	_name = name;
    	_age = age;
    }
} 
```

# Naming Method Parameters

The following rules outline the guidelines for naming parameters.
* ✔️ DO: Use Camel case.
* ✔️ DO: Use descriptive parameter names preferring a noun or noun phrase. Parameter names should be descriptive enough that the name of the parameter and its type can be used to determine its meaning in most scenarios.
* ✔️ DO: Use names that describe the parameters meaning rather than names that describe the field’s type.
* ❌ DO NOT: Use reserved parameters.
* ❌ DO NOT: Use Hungarian notation.

```C#
public void SetPosition(int x, int y) 
{ 
} 
public void CalculateProgress(int minimum, int maximum, int value) 
{ 
} 
public void DownloadFile(Uri uri, String filePath) 
{ 
}
```

:information_source: Hint: Generally you should follow the same guidelines for parameters as you do fields. You can differentiate between a field and parameter by using the this keyword.

# Documenting Code

Someone wrote a class, and now you need to consume its implementation. Where do you start? How do you use this class? What does it even do? These are all very common questions from developers when they first discover a type, and the answer to all of these questions is documenting the code itself. Have you often wondered why Msdn has such great documentation? I can tell you that it’s not because there is a technical documentation team doing all the work. Yes, there is a documentation team that does a lot of work, but the majority of the documentation already exists because it was documented by the developers who wrote the code and took the time to do it, in the actual code.
Visual Studio provides a rich means of documenting your code through Xml Documentation Comments. I also want to point out how incredibly easy this is to do, and how very little time it takes. Take the class I wrote in Class Structure, Figure 2; and in Visual Studio, place your cursor right above the class constructor and type /// (three forward slashes). You will notice that Visual Studio adds a bunch of stuff to your code.
Typing three forward slashes in Visual Studio automatically generates empty xml documentation comments for you to fill out. This is nice because no matter how many parameters you have, it will automatically provide you with ready to fill out comments for each one of them.
David Anderson: You can use this on almost anything, but there are some things that it will not work for, such as using directives to import namespaces and namespaces directly. Furthermore, even though you can document almost anything, you shouldn’t and should you should avoid over-documenting. There are ways to document code, and ways not to. Then there is also what to document, and what not to document. Luckily, the rules I usually give to developers to follow on this are very simple.

* ✔️ DO: Document a summary of all classes, regardless of their accessibility modifier.
* ✔️ DO: Document all public, protected, internal, and protected internal classes, constructors, methods, properties, constants, readonly static fields, events, and delegates.
* ❌ DO NOT: Document items that have a private accessibility modifier, unless it is very useful to do so, either because its implementation is large, complicated, or follows some complicated business rule that is hard to remember.

```C#
using System;
using System.Linq; 
namespace DCOMEngineering.DeveloperDocument.Demo
{
    /// <summary> 
    /// Provides information about a company employee. 
    /// </summary>     
    public class Employee 
    {
        private string _email;
        private string _name;
        private decimal _salary;
 
        /// <summary> 
        /// Initializes a new instance of the DCOMEngineering.DeveloperDocument.Demo.Employee class 
        /// using the specified name. 
        /// </summary> 
        /// <param name="name">The name of the employee.</param>
        public Employee(String name)
        {
            this._name = name; 
        } 
  
        /// <summary> 
        /// Gets or sets the employee's email address. 
        /// </summary>
        public String Email
        {
            get { return _email; }
            set { _email = value; } 
        } 
        /// <summary> 
        /// Gets or sets the employee's name. 
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; } 
        }  
        /// <summary> 
        /// Gets or sets the employee's salary. 
        /// </summary>
        public Decimal Salary
        {
            get { return _salary; }
            set { _salary = value; } 
        } 
    }
}
```

:information_source: Hint: If you’re wondering why you should use xml documentation comments rather than regular code comments, it’s because the xml comments are used by Visual Studio to provide information to Intellisense (the tooltip you get when you hover over an identifier in code). It’s a rich documentation set that allows you to even make bulleted lists in comments, and it’s even used to generate xml documentation comment files on disk that you can use to generate Msdn style documentation sites with. Let’s put these rules into practice and document our Employee class. I will demonstrate documenting the class itself, constructor, and its various properties.
Documentation is absolutely critical to writing high quality code. I always advocate what I read in Code Complete 2 by Microsoft, because it is one of the most accurate statements I have ever read about documentation in code.
Construction’s product, the source code, is often the only accurate description of the software.
In many projects, the only documentation available to programmers is the source code itself. Requirements specifications and design documents can go out of date, but the source code is always up to date. Consequently, it’s imperative that the source code be of the highest possible quality. Consistent application of techniques for sourcecode improvement makes the difference between a Rube Goldberg contraption and a detailed, correct, and therefore informative program. Such techniques are most effectively applied during construction.

# Documenting Classes

Document classes using a summary-description of what the class is, and preferably its overall purpose. Anyone reading the class summary should easily be able to deduce what the class’s purpose is.

```C#
/// <summary> 
/// Provides information about a company employee. 
/// </summary> 
public class Employee 
{ 
    … 
}
```

# Documenting Constructors

Document constructor’s using the following grammar: “Initializes a new instance of the
Namespace(s).ClassName class”. This provides consistency with how .NET Framework classes are documented, which will be familiar to most developers.

```C#
/// <summary> 
/// Initializes a new instance of the DCOMEngineering.DeveloperDocument.Demo.Employee class. 
/// </summary>
public Employee() 
{ 
}
```

# Documenting Events

Document events such as “Occurs when …”. This provides consistency with how .NET Framework events are documented, which will be familiar to most other developers.

```C#
/// <summary> 
/// Occurs when the progress of the file download has been changed. 
/// </summary> 
public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
```

As you can clearly see, documentation can easily become quite a large subject to discuss. However, I have covered enough to give you a good foundation to start documenting your classes well, adding that extra layer of quality. You will find that other developers reading your code will not have a difficult time, and the even better news is that neither will you two weeks from now when you have to go back and read it again.

* ✔️ DO: Use the tag to document private implementation details for other developers to understand.
* ✔️ DO: Favor the tag over the tag if there is a good probability of using documentation generation in the future.
* ✔️ DO: Be extremely consistent in your documentation while being as articulate and precise as possible.
* ❌ DO NOT: Document private fields, unless there is a very good reason to do so.
* ❌ DO NOT: Use normal code comments for documentation. These are included in compiled source code and create code bloat. Xml documentation comments are stripped from the source code when it is compiled, and are not included in the final output assembly.

# Documenting Properties

Document properties first with “Gets or sets …”, “Gets …”, or “Sets …” following by its summary description. This clearly indicates to a developer whether the property is read-only, read-write, or write-only. This provides consistency with how .NET Framework properties are documented, which will be familiar to most developers.

```C#
/// <summary> 
/// Gets or sets the employee's email address. 
/// </summary> 
public String Email 
{
     get { return _email; }
     set { _email = value; } 
} 
  
/// <summary> 
/// Gets the employee's name. 
/// </summary> 
public String Name 
{
     get { return _name; } 
}
```

# Documenting Methods

Document methods using a summary description of what the method’s action is, being as precise as possible. Describing a method’s action is generally more difficult than describing a simple property or class, so make sure to give it the time and thought to produce the most clearly understandable description you can. Optionally, use the or tags to provide technical details that are more in-depth than a summary description.

```C#
/// <summary> 
/// Calculates the employee's base salary. 
/// </summary> 
/// <param name="hourlyRate">The hourly rate the employee makes.</param> 
/// <devdoc> 
/// At our company, a salary is based on a 300-day work-year
/// with 8 billable work hours per day. 
/// </devdoc> 
public decimal CalculateSalary(decimal hourlyRate) 
{
     return (hourlyRate * 8) * 300; 
}
```

Method documentation is arguably the most critical documentation in your class, because methods generally contain almost all of your class’s behavior. In Figure 8, you see the summary description that describes what the method’s action is, but in addition you have documentation for the arguments it takes as parameters too. This is important because a developer needs to know what a parameter is, and what it expects as an argument so that they can use the method correctly.
In addition to the standard documentation, you will note that there is also a tag that is not listed in the table I outlined earlier in this section. The tag is a little secret that I believe originated from the .NET Framework team at Microsoft to indicate that a comment was directly from the developer, and not the documentation team. This is very useful because you may not end up writing all the documentation, but still may need to provide your input to some degree.
David Anderson: When a method’s implementation is too complicated to explain without forgetting a bunch of details, has unique business rules, or there is something else about it that warrants some detailed explanation, you should prefer to use the tag. The advantage of the tag is that it is generally included by documentation generators like Msdn where you see a remarks section. In most cases though, development teams do not generate documentation sites, and use the code itself as documentation. In these scenarios, favor the tag while still considering that you might use a documentation generator in the future.
