using System;
using System.Collections.Generic;

namespace DirectGraph.FormCodeProject
{
    public class TopologicalSort<T> where T : IHaveDependencies<T>
    {
        List<T> sorted;
        Dictionary<T, bool> visited;

        public TopologicalSort(IEnumerable<T> source)
        {
            sorted = new List<T>();
            visited = new Dictionary<T, bool>();

            foreach (T item in source)
            {
                Visit(item);
            }
        }

        private void Visit(T item)
        {
            bool inProcess;
            bool alreadyVisited = visited.TryGetValue(item, out inProcess);

            if (alreadyVisited)
            {
                if (inProcess)
                {
                    throw new ArgumentException("Cyclic dependency found.");
                }
            }
            else
            {
                visited[item] = true;
                foreach (T dependency in item.Dependencies)
                {
                    Visit(dependency);
                }

                visited[item] = false;
                sorted.Add(item);
            }

        }
    }
}