using System;
using System.Collections.Generic;
using System.Linq;

namespace Skibitsky.Asuka
{
    public static class EnumerableExtensions
    {
        // https://stackoverflow.com/a/7259419
        public static T RandomElement<T>(this IEnumerable<T> source) => 
            source.RandomElementUsing<T>(new Random());

        public static T RandomElementUsing<T>(this IEnumerable<T> source, Random rand)
        {
            var array = source as T[] ?? source.ToArray();
            var index = rand.Next(0, array.Length);
            return array.ElementAt(index);
        }
    }
}