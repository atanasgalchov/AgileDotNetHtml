using System;
using System.Collections.Generic;

namespace AgileDotNetHtml.Interfaces
{
    public interface IHtmlElementsCollection : IList<IHtmlElement>
    {
        IHtmlElement Get(string uid);
        IHtmlElement FirstOrDefault();
        IHtmlElement FirstOrDefault(Func<IHtmlElement, bool> predicate);
        IHtmlElement LastOrDefault();
        bool Any(Func<IHtmlElement, bool> predicate);
        void AddBefore(string uid, IHtmlElement tag);
        void AddAfter(string uid, IHtmlElement tag);
        void Remove(string uid);
        void RemoveAll(string name);
		void AddRange(IEnumerable<IHtmlElement> enumerable);
        List<IHtmlElement> ToList();
	}
}
