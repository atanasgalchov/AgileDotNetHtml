using AgileDotNetHtml.Attributes;

namespace AgileDotNetHtml.Models.HtmlElements
{
	[HtmlElementClass("input")]
	public class HtmlInputElement : HtmlSelfClosingTagElement
	{
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlInputElement class represent HTML &lt;input&gt; tag.
		/// </summary>
		public HtmlInputElement() : base("input") { }
		/// <summary>
		/// Initialize a new instance of AgileDotNetHtml.Models.HtmlElements.HtmlInputElement class represent HTML &lt;input&gt; tag.
		/// </summary>
		/// <param name="inputType">Input type attribute.</param>
		public HtmlInputElement(string inputType): this()
		{
			InputType = inputType;
		}

		public string InputType 
		{
			get
			{ 
				return GetAttribute("type")?.Value; 
			} 
			set 
			{ 				
				AddAttributeValue("type", value); 
			}
		}
		public string Value
		{
			get
			{
				return GetAttribute("value")?.Value;
			}
			set
			{
				AddAttributeValue("value", value);
			}
		}
		public string Name 
		{
			get
			{
				return GetAttribute("name")?.Value;
			}
			set
			{
				AddAttributeValue("name", value);
			}
		}
	}
}

