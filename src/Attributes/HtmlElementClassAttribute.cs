using System;

namespace AgileDotNetHtml.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class HtmlElementClassAttribute : Attribute
	{
		internal HtmlElementClassAttribute(string tagName)
		{
			TagName = tagName;
		}

		internal string TagName { get; set; }
	}
}
