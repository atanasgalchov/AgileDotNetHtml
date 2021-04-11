using AgileDotNetHtml.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AgileDotNetHtml.Models
{
    public class HtmlElementsCollection : IHtmlElementsCollection
    {
        private List<IHtmlElement> _list = new List<IHtmlElement>();
        protected List<IHtmlElement> List { get { return _list; } }
		public int Count =>_list.Count;
		public bool IsReadOnly => throw new NotImplementedException();

		public HtmlElementsCollection()
		{

		}
		public HtmlElementsCollection(IHtmlElement[] elements)
		{
            _list.AddRange(elements);

        }

        public IHtmlElement this[int index]
        {
            get
            {
                return this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }

        public IHtmlElement FirstOrDefault() 
        {
            return _list.FirstOrDefault();
        }
        public IHtmlElement FirstOrDefault(Func<IHtmlElement, bool> predicate)
        {
            IHtmlElement element = null;
            foreach (var item in _list)
			{
                if (predicate((IHtmlElement)item))
                {
                    element = (IHtmlElement)item;
                    break;
                }              
			}
            return element;
        }
        public IHtmlElement LastOrDefault()
        {
            return _list.LastOrDefault();
        }
        public bool Any(Func<IHtmlElement, bool> predicate)
        {
            bool any = false;
            foreach (var item in _list)
            {
                if (predicate((IHtmlElement)item))
                {
                    any = true;
                    break;
                }
            }
            return any;
        }
        public void Add(IHtmlElement tag)
        {
            _list.Add(tag);
        }
        public void AddRange(IEnumerable<IHtmlElement> enumerable)
        {
            _list.AddRange(enumerable);
        }
        public void AddAfter(string uid, IHtmlElement tag)
        {
            int index = _list.IndexOf(Get(uid)) + 1;
            _list.Insert(index, tag);
        }
        public void AddBefore(string uid, IHtmlElement tag)
        {
            int index = _list.IndexOf(Get(uid)) - 1;
            _list.Insert(index, tag);
        }
        public IHtmlElement Get(string uid)
        {
            IHtmlElement htmlElement = List.FirstOrDefault(x => x.UId == uid);
            if (htmlElement != null)
                return htmlElement;

            foreach (var element in List)
            {
                if (element is IHtmlNodeElement)
                {
                    htmlElement = ((IHtmlNodeElement)element).Children?.Get(uid);
                    if (htmlElement != null)
                        break;
                }
            }
           
            return htmlElement;
        }
        public void Remove(string uid)
        {
            _list.RemoveAll(x => x.UId == uid);
        }
        public void RemoveAll(string name)
        {
            _list.RemoveAll(x => x.TagName == name);
        }
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);

        }
        public bool Remove(IHtmlElement item)
        {
           return _list.Remove(item);
        }
        public int IndexOf(IHtmlElement item)
		{
            return _list.IndexOf(item);
		}
		public void Insert(int index, IHtmlElement item)
		{
            _list.Insert(index, item);
		}	
        public void Clear()
		{
            _list.Clear();
        }
		public bool Contains(IHtmlElement item)
		{
            return _list.Contains(item);
        }
		public void CopyTo(IHtmlElement[] array, int arrayIndex)
		{
            _list.CopyTo(array, arrayIndex);
        }
        public List<IHtmlElement> ToList()
        {
            return _list.ToList();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<IHtmlElement> GetEnumerator()
        {
            foreach (var element in List)
            {
                yield return element;
            }
        }

        public static implicit operator HtmlElementsCollection(List<IHtmlElement> htmlElements) 
        {
            HtmlElementsCollection result = new HtmlElementsCollection();
            result.AddRange(htmlElements);

            return result;
        }
        public static implicit operator List<IHtmlElement>(HtmlElementsCollection htmlElements)
        {
            List<IHtmlElement> result = new List<IHtmlElement>();
            result.AddRange(htmlElements.ToList());

            return result;
        }
    }
}
