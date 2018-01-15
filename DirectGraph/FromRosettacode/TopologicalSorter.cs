using System;
using System.Collections.Generic;
using System.Linq;

namespace DirectGraph.FromRosettacode
{
    public class TopologicalSorter<T>
    {
        private class Inclusion
        {
            public int ArgCount = 0;
            public HashSet<T> IncludedInFuncs = new HashSet<T>();
        }

        private Dictionary<T, Inclusion> map = new Dictionary<T, Inclusion>();
        //                 A        B
        public void Add(T func, T arg)
        {
            if (arg.Equals(func)) return;

            if (!map.ContainsKey(arg))
            {
                map.Add(arg, new Inclusion()); // [B, new Relations()]
            }

            HashSet<T> includedInFuncs = map[arg].IncludedInFuncs;

            if (!includedInFuncs.Contains(func))
            {
                includedInFuncs.Add(func); // [B, [A]]

                if (!map.ContainsKey(func))
                {
                    map.Add(func, new Inclusion()); // [A, new Relations() ]
                }

                map[func].ArgCount += 1; // [A, {dCount = 1, [] }]
            }
        }

        public void Add(T func, params T[] args)
        {
            Array.ForEach(args, arg => Add(func, arg));
        }

        public Tuple<IEnumerable<T>, IEnumerable<T>> Sort()
        {
            List<T> sorted = new List<T>();
            List<T> cycled = new List<T>();
            IEnumerable<T> zeroDep;
            var map = this.map.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            zeroDep = map.Where(kvp => kvp.Value.ArgCount == 0).Select(kvp => kvp.Key).ToArray();
            sorted.AddRange(zeroDep);

            for (int inx = 0; inx < sorted.Count; inx++)
            {
                Inclusion inclusion = map[sorted[inx]]; // get source inclusion
                zeroDep = inclusion.IncludedInFuncs.Where(incInFunc => (--map[incInFunc].ArgCount) == 0).ToArray();
                sorted.AddRange(zeroDep);
            }

            cycled.AddRange(map.Where(kvp => kvp.Value.ArgCount != 0).Select(kvp => kvp.Key));

            return new Tuple<IEnumerable<T>, IEnumerable<T>>(sorted, cycled);
        }
    }
}
