using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DirectGraph.FormCodeProject
{
    public class TopologicalGrouping<T> where T : IHaveDependencies<T>
    {
        public List<ICollection<T>> sorted;
        private Dictionary<T, int> visited;

        public TopologicalGrouping(IEnumerable<T> source, IEqualityComparer<T> comparer = null)
        {
            sorted = new List<ICollection<T>>();
            visited = new Dictionary<T, int>(comparer);

            foreach (T item in source)
            {
                Visit(item);
            }
        }

        private int Visit(T item)
        {
            const int inProcess = -1;
            int level;
            var alreadyVisited = visited.TryGetValue(item, out level);

            if (alreadyVisited)
            {
                if (level == inProcess)
                {
                    throw new ArgumentException("Cyclic dependency found.");
                }
            }
            else
            {
                visited[item] = (level = inProcess);
                foreach (T dependency in item.Dependencies)
                {
                    int depLevel = Visit(dependency);
                    level = Math.Max(level, depLevel);
                }

                visited[item] = ++level;
                while (sorted.Count <= level)
                {
                    sorted.Add(new Collection<T>());
                }
                sorted[level].Add(item);
            }

            return level;
        }
    }
}
