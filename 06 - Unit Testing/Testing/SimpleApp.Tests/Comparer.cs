using System;
using System.Collections.Generic;

namespace SimpleApp.Tests
{
    public class Comparer
    {
        public static Comparer<U?> Get<U>(Func<U?, U?, bool> func)
        {
            return new Comparer<U?>(func);
        }
    }

    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private Func<T?, T?, bool> comparisonFunction;
        //private Predicate<T?, T?> comparisonFunction;  // Predicate only accept one Type

        public Comparer(Func<T?, T?, bool> func)
        {
            comparisonFunction = func;
        }

        //public Comparer(Predicate<T?, T?> func) // Predicate only accept one Type
        //{
        //    comparisonFunction = func;
        //}

        public bool Equals(T? x, T? y)
        {
            return comparisonFunction(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj?.GetHashCode() ?? 0;
        }
    }
}
