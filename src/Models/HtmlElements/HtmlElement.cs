using AgileDotNetHtml.Interfaces;
using AgileDotNetHtml.Models.HtmlAttributes;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgileDotNetHtml.Models.HtmlElements
{
	public class HtmlElement : IHtmlElement
    {
        protected string _uid;
        protected string _tagName;
        protected List<IHtmlAttribute> _attributes { get; set; } = new List<IHtmlAttribute>();

        public HtmlElement(string tagName)
        {
            _uid = Guid.NewGuid().ToString().Replace("-", "");
            _tagName = tagName;
        }
        public string UId => _uid;
        public string TagName => _tagName;
        public IHtmlElementsCollection Parents { get; set; } = new HtmlElementsCollection();
        public IHtmlAttribute[] Attributes
        {
            get
            {
                return _attributes.ToArray();
            }
            set
            {
                _attributes = new List<IHtmlAttribute>(value != null ? value : new HtmlAttribute[] { });
            }
        }

        public virtual HtmlElement Clone()
        {
            return (HtmlElement)this.MemberwiseClone();
        }
        public void AddAttribute(IHtmlAttribute attribute)
        {
            if (attribute != null)
            {
                _attributes.RemoveAll(x => x.Name == attribute.Name);

                _attributes.Add(attribute);
            }
        }
        public void AddAttribute(string name)
        {
            AddAttribute(new HtmlAttribute(name));
        }
        public void AddAttributeValue(string Name, string Value)
        {
            if (!_attributes.Any(x => x.Name == Name))
                _attributes.Add(new HtmlAttribute(Name));

            _attributes.Find(x => x.Name == Name).Value = Value;
        }
        public void AddRangeAttributes(IHtmlAttribute[] Attributes)
        {
            _attributes.AddRange(Attributes);
        }
        public IHtmlAttribute GetAttribute(string Name)
        {
            return _attributes.FirstOrDefault(x => x.Name == Name);
        }
        public bool HasAttribute(string Name)
        {
            return _attributes.Any(x => x.Name == Name);
        }
        public void MergeAttributes(IHtmlAttribute[] Attributes)
        {
            throw new NotImplementedException();
        }
        public void RemoveAttribute(string Name)
        {
            throw new NotImplementedException();
        }
        public void ReplaceAttributeValue(string Name, string Value)
        {
            throw new NotImplementedException();
        }
    }
}
