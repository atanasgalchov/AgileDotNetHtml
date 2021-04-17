using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	[HtmlAttributeClass("draggable")]
	public class HtmlDraggableAttribute : HtmlAttribute
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlAttributes.HtmlDraggableAttribute class represent HTML draggable attribute.
		/// </summary>
		public HtmlDraggableAttribute(string value) : base("draggable", value)
		{
		}
	}
}
