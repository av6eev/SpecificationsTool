using System;
using System.Collections.Generic;
using System.Linq;

namespace Editor.Extensions
{
    public static class ListExtension
    {
        public static bool TryGetElementByIndex<T>(this List<T> list, int index, out T element)
        {
            var e = list.ElementAtOrDefault(index);
            if (e != null)
            {
                element = e;
                return true;
            }

            element = default;
            return false;
        }
    }
}