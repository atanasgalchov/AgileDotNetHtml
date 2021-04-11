using AgileDotNetHtml.Interfaces;

namespace AgileDotNetHtml.Factories.HtmlAttributes
{
	public class HtmlStyleAttributeFactory : HtmlAttributeFactory
	{
		public HtmlStyleAttributeFactory() : base("style")
		{
		}

		public override IHtmlAttribute Create(string nameValueAttributeString)
		{
			return base.Create(nameValueAttributeString);
		}
	}
}
