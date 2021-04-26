using System;

namespace AgileDotNetHtml.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class HtmlAttributeClassAttribute : Attribute
	{
		public HtmlAttributeClassAttribute(string attributeName)
		{
			AttributeName = attributeName;
		}
		public HtmlAttributeClassAttribute(string attributeName, string[] belongsToElements)
		{
			AttributeName = attributeName;
			BelongsToElements = belongsToElements;
		}

		public string AttributeName { get; set; }
		public string[] BelongsToElements { get; set; }
	}
}
