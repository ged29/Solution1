using System;

namespace DirectGraph.FormCodeProject
{
    public class Item : IHaveDependencies<Item>
    {
        public string Name { get; private set; }
        public Item[] Dependencies { get; private set; }

        public Item(string name, params Item[] dependencies)
        {
            Name = name;
            Dependencies = dependencies;
        }

        public override string ToString()
        {
            return string.Format("{0} : [{1}]",
                Name, String.Join(" , ", Array.ConvertAll(Dependencies, x => x.Name)));
        }
    }

    public interface IHaveDependencies<T>
    {
        T[] Dependencies { get; }
    }
}