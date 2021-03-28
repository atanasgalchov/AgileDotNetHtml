using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models;
using System;
using System.Web;

namespace AgileDotNetHtml.ClassFactory
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
