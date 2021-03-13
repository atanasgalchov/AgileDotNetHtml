using AgileDotNetHtml.HtmlAttributes;
using AgileDotNetHtml.Interfaces;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Xml;

namespace AgileDotNetHtml
{
   public class HtmlElement : IHtmlElement
    {
        private string _uid;
        private string _tagName;
        private HtmlString _text = HtmlString.Empty;
        private int _textIndex;
        private List<IHtmlAttribute> _attributes { get; set; } = new List<IHtmlAttribute>();
        private IHtmlElementsCollection _children { get; set; } = new HtmlElementsCollection();
        public HtmlElement(string tagName)
        {
            _uid = Guid.NewGuid().ToString().Replace("-","");
            _tagName = tagName;
        }
		public HtmlElement(string tagName, string text): this (tagName)
		{
            _text = new HtmlString(text);
        }
        public string UId => _uid;
        public string TagName => _tagName;
        public int TextIndex => _textIndex;
       
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
        public void Text(string html)
        {
            _text = new HtmlString(html);
            _textIndex = 0;
        }
        public void Text(string html, int index)
        {
            _text = new HtmlString(html);
            _textIndex = index;
        }
        public void Text(HtmlString html)
        {
            _text = html;
            _textIndex = 0;
        }
        public void Text(HtmlString html, int index)
        {
            _text = html;
            _textIndex = index;
        }

        public HtmlString Text()
        {
            return _text;
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



        // TODO Implemnet
        public static IHtmlElement Parse(string htmlString)
        {
            if (htmlString == null)
                throw new ArgumentException("htmlString");



            throw new NotImplementedException("");
        }
    }
}
