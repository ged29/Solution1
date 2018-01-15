using System;
using System.Collections.Generic;

namespace DirectGraph.FormCodeProject
{
    public class Item : IHaveDependencies<Item>
    {
        public string Name { get; private set; }
        public Item[] Dependencies { get; private set; }
        public int Level { get; set; }

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

    public class ItemEqualityComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            return (x == null && y == null) || (x != null && y != null && x.Name == y.Name);
        }

        public int GetHashCode(Item obj)
        {
            return obj == null ? 0 : obj.Name.GetHashCode();
        }
    }

    public interface IHaveDependencies<T>
    {
        T[] Dependencies { get; }
    }
}