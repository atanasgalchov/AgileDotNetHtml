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
			foreach (var newAttribute in Attributes)
			{
                IHtmlAttribute existingAttribute = _attributes.FirstOrDefault(x => x.Name == newAttribute.Name);
                if (existingAttribute != null)
                    existingAttribute.Value = $"{existingAttribute.Value ?? ""} {newAttribute.Value}";
            }
        }
        public void RemoveAttribute(string Name)
        {
            IHtmlAttribute attribute = _attributes.FirstOrDefault(x => x.Name == Name);
            if (attribute != null)
                _attributes.Remove(attribute);
        }
        public void ReplaceAttributeValue(string Name, string Value)
        {
            IHtmlAttribute attribute = _attributes.FirstOrDefault(x => x.Name == Name);
            if (attribute != null)
                attribute.Value = Value;
        }
        public void AddClass(string className) 
        {
            IHtmlAttribute classAttribute = _attributes.FirstOrDefault(x => x.Name == "class");
            if (classAttribute != null)
                classAttribute.Value = $"{classAttribute.Value ?? ""} {className}";

            _attributes.Add(new HtmlClassAttribute(className));
        }
        public void RemoveClass(string className)
        {
            IHtmlAttribute classAttribute = _attributes.FirstOrDefault(x => x.Name == "class");
            if (classAttribute != null)
                _attributes.Remove(classAttribute);
        }

        public void ToogleClass(string className)
        {
            IHtmlAttribute classAttribute = _attributes.FirstOrDefault(x => x.Name == "class");
            if (classAttribute != null)
                RemoveClass(className);
            else
                AddClass(className);
        }
    }
}
