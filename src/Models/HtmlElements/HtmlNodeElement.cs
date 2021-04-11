﻿using AgileDotNetHtml.Interfaces;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileDotNetHtml.Models.HtmlElements
{
	public class HtmlNodeElement : HtmlPairTagsElement, IHtmlNodeElement
	{
        private IHtmlElementsCollection _children { get; set; } = new HtmlElementsCollection();
        private List<HtmlElementText> _textsBetweenChildren = new List<HtmlElementText>();
        public HtmlNodeElement(string tagName) : base(tagName)
		{
		}
		public HtmlNodeElement(string tagName, string text) : base(tagName, text)
		{                
		}

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

        public IHtmlElement Find(Func<IHtmlElement, bool> predicate)
        {
            IHtmlElement htmlElement = Children.FirstOrDefault(predicate);
            if (htmlElement != null)
                return htmlElement;
      
            foreach (var element in Children.Where(x => x is IHtmlNodeElement))
            {
                htmlElement = ((IHtmlNodeElement)element).Find(predicate);
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
        public void Text(HtmlElementText[] texts)
        {
			foreach (var text in texts)			
                text.HtmlString = new HtmlString(HttpUtility.HtmlDecode(text.HtmlString.Value));
			
            _textsBetweenChildren = texts.ToList();
        }
        public HtmlElementText[] Texts()
        {
            if (_text != null)
                return _textsBetweenChildren.Prepend(new HtmlElementText(_text, null)).ToArray();

            return _textsBetweenChildren.ToArray();
        }
        public override HtmlString Text()
        {
            return new HtmlString(String.Join("", Texts().Select(x => x.HtmlString)));
        }
        public void Text(string html, string afterElementUId)
        {
            _textsBetweenChildren.Add(new HtmlElementText(new HtmlString(HttpUtility.HtmlDecode(html)), afterElementUId));
        }
        public void Text(HtmlString html, string afterElementUId)
        {
            html = new HtmlString(HttpUtility.HtmlDecode(html.Value));
            _textsBetweenChildren.Add(new HtmlElementText(html, afterElementUId));
        }
        private void SetElementParent(IHtmlElement element)
        {
            element.Parents.Add(this);
            if(element is IHtmlNodeElement)
                SetChildrenParent(((IHtmlNodeElement)element).Children);
        }
        private void SetChildrenParent(IHtmlElementsCollection children)
        {
            foreach (var element in children)
            {
                element.Parents.Add(this);
                if(element is IHtmlNodeElement)
                    if (((IHtmlNodeElement)element).Children.Count() > 0)
                        SetChildrenParent(((IHtmlNodeElement)element).Children);
            }
        }
    }
}