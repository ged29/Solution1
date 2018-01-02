using System;
using System.Collections.Generic;

namespace Chapter3
{
    public sealed class Pair<T1, T2> : IEquatable<Pair<T1, T2>>
    {
        public T1 First { get; private set; }
        public T2 Second { get; private set; }

        // Returns a default equality comparer for the T1
        private static readonly IEqualityComparer<T1> FirstParamComparer = EqualityComparer<T1>.Default;
        // Returns a default equality comparer for the T2
        private static readonly IEqualityComparer<T2> SecondParamComparer = EqualityComparer<T2>.Default;

        public Pair(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        public bool Equals(Pair<T1, T2> other)
        {
            return other != null
                && FirstParamComparer.Equals(First, other.First)
                && SecondParamComparer.Equals(Second, other.Second);
        }

        public override bool Equals(object other)
        {
            return Equals(other as Pair<T1, T2>);
        }

        public override int GetHashCode()
        {
            return FirstParamComparer.GetHashCode(First) * 37 + SecondParamComparer.GetHashCode(Second);
        }
    }

    public static class Pair
    {
        public static Pair<T1, T2> Of<T1, T2>(T1 first, T2 second)
        {
            return new Pair<T1, T2>(first, second);
        }
    }
}
