using AgileDotNetHtml.Interfaces;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgileDotNetHtml.Models
{
	public class HtmlElement : IHtmlElement
    {
        private string _uid;
        private string _tagName;
        private List<HtmlElementText> _texts = new List<HtmlElementText>();
        private List<IHtmlAttribute> _attributes { get; set; } = new List<IHtmlAttribute>();
        private IHtmlElementsCollection _children { get; set; } = new HtmlElementsCollection();
       
        public HtmlElement(string tagName)
        {
            _uid = Guid.NewGuid().ToString().Replace("-","");
            _tagName = tagName;
        }
		public HtmlElement(string tagName, string text): this (tagName)
		{
            Text(text);
        }
      
        public string UId => _uid;
        public string TagName => _tagName;  
        public IHtmlElementsCollection Children 
        {
            get { return _children; } 
            set 
            { 
                if (value != null) 
                {
                    SetChildrenParent(new List<IHtmlElement> { this }, value);
                }

                _children = value;
            } 
        }
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

        public IHtmlElement Find(Func<IHtmlElement, bool> predicate)
        {
            IHtmlElement htmlElement = Children.FirstOrDefault(predicate);
            if (htmlElement != null)
                return htmlElement;

            foreach (var element in Children)
            {
                htmlElement = element.Children?.FirstOrDefault(predicate);
                if (htmlElement != null)
                    break;
            }

            return htmlElement;
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
        public void Append(IHtmlElement element)
        {
            Children.Add(element);
        }
        public void Prepend(IHtmlElement element)
        {
            Children.Prepend(element);
        }
        public HtmlString Text()
        {
            return new HtmlString(String.Join("", Texts().Select(x => x.HtmlString)));
        }
        public HtmlElementText[] Texts()
        {
            return _texts.ToArray();
        }
        public void Text(string html)
        {
            Text(new HtmlString(html));
        }
        public void Text(HtmlString html)
        {
            Text(html, 0);
        }
        public void Text(string html, int index)
        {
            Text(new HtmlString(html), index);
        }
        public void Text(HtmlString html, int index)
        {
            if (index > Children.Count)
                index = Children.Count;

            if (index < 0)
                index = 0;

            _texts.Add(new HtmlElementText(html, index));
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
        private void SetChildrenParent(IEnumerable<IHtmlElement> parents, IHtmlElementsCollection children) 
        {
			foreach (var item in children)
			{
                item.Parents.AddRange(parents);
                var childParents = parents.ToList();
                childParents.Insert(0, item);
                SetChildrenParent(childParents, item.Children);
            }
        }
    }
}
