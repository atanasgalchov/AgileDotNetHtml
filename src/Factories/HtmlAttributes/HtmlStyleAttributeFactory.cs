using AgileDotNetHtml.Interfaces;

namespace AgileDotNetHtml.Factories.HtmlAttributes
{
	internal class HtmlStyleAttributeFactory : HtmlAttributeFactory
	{
		internal HtmlStyleAttributeFactory() : base("style")
		{
		}

		public override IHtmlAttribute Create(string nameValueAttributeString)
		{
			return base.Create(nameValueAttributeString);
		}
	}
}
