using AgileDotNetHtml.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AgileDotNetHtml.Models.HtmlAttributes
{
	public class HtmlAttributesCollection : IEnumerable<IHtmlAttribute>
	{
		private List<IHtmlAttribute> _list = new List<IHtmlAttribute>();
        protected List<IHtmlAttribute> List { get { return _list; } }

        public HtmlAttributesCollection()
		{

		}
		public HtmlAttributesCollection(params IHtmlAttribute[] attributes)
		{
			_list.AddRange(attributes);
		}

        public IHtmlAttribute this[int index]
        {
            get
            {
                return (IHtmlAttribute)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }

        public void Add(IHtmlAttribute attribute)
        {
            _list.Add(attribute);
        }
        public void AddRange(IEnumerable<IHtmlAttribute> enumerable)
        {
            _list.AddRange(enumerable);
        }     
        public void Remove(IHtmlAttribute attribute)
        {
            _list.Remove(attribute);
        }
        public void RemoveAll(Predicate<IHtmlAttribute> math)
        {
            _list.RemoveAll(math);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<IHtmlAttribute> GetEnumerator()
        {
            foreach (var element in List)
            {
                yield return element;
            }
        }
        public Dictionary<string, string> ToDictionary() 
        {
            var result = new Dictionary<string, string>();

			foreach (var item in _list)
			{
                if(!result.ContainsKey(item.Name))
                    result.Add(item.Name, null);

                if (item.Value != null)
                    result[item.Name] = result[item.Name] != null ?  $"{result[item.Name]}{item.Value}" : item.Value;
            }

            return result;
        }


        public static implicit operator IHtmlAttribute[](HtmlAttributesCollection collection)
        {
            return collection?._list.ToArray();
        }

        public static implicit operator HtmlAttributesCollection(IHtmlAttribute[] array)
        {
            return new HtmlAttributesCollection(array);
        }
    }
}
