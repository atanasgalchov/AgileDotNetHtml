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
            get 
            {
                return _children;
            } 
            set 
            { 
                if (value != null)
                    SetChildrenParent(value);
                
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

        public virtual HtmlElement Clone() 
        {
            return (HtmlElement)this.MemberwiseClone();
        }
        public IHtmlElement Find(Func<IHtmlElement, bool> predicate)
        {
            IHtmlElement htmlElement = Children.FirstOrDefault(predicate);
            if (htmlElement != null)
                return htmlElement;

            foreach (var element in Children)
            {
                htmlElement = element.Find(predicate);
                if (htmlElement != null)
                    break;
            }

            return htmlElement;
        }
        public void Append(IHtmlElement element) 
        {
            SetElementParent(element);
            _children = (HtmlElementsCollection)_children.Append(element).ToList();
        }
        public void AppendRange(IHtmlElementsCollection elements)
        {
			foreach (var item in elements)
                Append(item);
        }
        public void Preppend(IHtmlElement element)
        {
            SetElementParent(element);
            _children.Prepend(element);
        }
        public void PreppendRange(IHtmlElementsCollection elements)
        {
            foreach (var item in elements)
                Preppend(item);
        }
        public void ClearChildren()
        {
            _children.Clear();
        }
        public void Insert(int index, IHtmlElement element)
        {
            SetElementParent(element);
            _children.Insert(index, element);
        }
        public void InsertRange(int startIndex, IHtmlElementsCollection elements)
        {
            foreach (var item in elements)
                Insert(startIndex++, item);
        }
        public void AddAfter(string uid, IHtmlElement element)
        {
            int index = _children.IndexOf(_children.Get(uid)) + 1;
            _children.Insert(index, element);
        }
        public void AddBefore(string uid, IHtmlElement element)
        {
            int index = _children.IndexOf(_children.Get(uid)) - 1;
            _children.Insert(index, element);
        }
        public void RemoveChild(string uid)
        {
            IHtmlElement element = _children.FirstOrDefault(x => x.UId == uid);
            _children.Remove(element);
        }
        public void RemoveAllChildren(string name)
        {
			foreach (var item in _children.Where(x => x.TagName == name))			
                _children.Remove(item);
        }
        public void RemoveChildAt(int index)
        {
            _children.RemoveAt(index);

        }
        public bool RemoveChild(IHtmlElement item)
        {
            return _children.Remove(item);
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
            Text(html, null);
        }
        public void Text(string html, string afterElementUId)
        {
            Text(new HtmlString(html), afterElementUId);
        }
        public void Text(HtmlString html, string afterElementUId)
        {
            _texts.Add(new HtmlElementText(html, afterElementUId));
        }
        private void SetElementParent(IHtmlElement element)
        {
            element.Parents.Add(this);
            SetChildrenParent(element.Children);
        }
        private void SetChildrenParent(IHtmlElementsCollection children)
        {
			foreach (var item in children)
			{
                item.Parents.Add(this);
                if(item.Children.Count() > 0)                
                    SetChildrenParent(item.Children);
            }
        }
    }
}
