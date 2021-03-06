using System;
using System.Collections.Generic;
using System.Linq;

namespace AgileDotNetHtml.Extensions
{
    internal static class StringExtensions
    {
        public static bool IsEqualIgnoreCase(this string str, string copareString) => str.Equals(copareString, StringComparison.InvariantCultureIgnoreCase);
    }
    internal static class ArrayExtensions
    {
        public static bool IsNull(this IEnumerable<object> array) => array == null;
        public static bool IsEmpty(this IEnumerable<object> array) => !array.Any();
        public static bool IsNullOrEmpty(this IEnumerable<object> array) => IsNull(array) || IsEmpty(array);
        public static bool IsNotNullAndNotEmpty(this IEnumerable<object> array) => !IsNull(array) && !IsEmpty(array);

        public static bool IsNull(this ICollection<object> array) => array == null;
        public static bool IsEmpty(this ICollection<object> array) => !array.Any();
        public static bool IsNullOrEmpty(this ICollection<object> array) => IsNull(array) || IsEmpty(array);
        public static bool IsNotNullAndNotEmpty(this ICollection<object> array) => !IsNull(array) && !IsEmpty(array);
    }
}
