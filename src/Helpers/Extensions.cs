using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AgileDotNetHtml.Helpers.Extensions
{
    internal static class StringExtensions
    {
        public static bool IsEqualIgnoreCase(this string str, string compareString) => str.Equals(compareString, StringComparison.InvariantCultureIgnoreCase);
        public static bool IsNullOrEmpty(this string str) => str == null || str.Trim() == String.Empty;
        public static bool IsNotNullNorEmpty(this string str) => str != null && str.Trim() != String.Empty;
        public static bool NotStarstWith(this string str, string value) => !str.StartsWith(value);
        public static bool NotEndstWith(this string str, string value) => !str.EndsWith(value);
        public static bool StarstWithPattern(this string str, string pattern) => Regex.IsMatch(str.TrimStart(), pattern);
        public static bool EndstWithPattern(this string str, string pattern) => str.TrimEnd().Length - (Regex.Match(str.TrimEnd(), pattern, RegexOptions.RightToLeft).Index + Regex.Match(str.TrimEnd(), pattern, RegexOptions.RightToLeft).Value.Length) == 0;
        public static bool NotStarstWithPattern(this string str, string pattern) => !str.StarstWithPattern(pattern);
        public static bool NotEndstWithPattern(this string str, string pattern) => !str.EndstWithPattern(pattern);
        public static string SubStringToIndex(this string str, int startIndex, int endIndex) 
        {
            int length = endIndex - startIndex + 1;
            return str.Substring(startIndex, length);
        }
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
