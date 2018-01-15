using System.Collections.Generic;

namespace DirectGraph
{
    public class DepthFirstOrder
    {
        private bool[] visited;
        private bool[] inStack;
        private Queue<int> preOrder;
        private Queue<int> postOrder;
        private Stack<int> reversePostOrder;

        public DepthFirstOrder(Digraph digraph)
        {
            preOrder = new Queue<int>();
            postOrder = new Queue<int>();
            reversePostOrder = new Stack<int>();
            visited = new bool[digraph.NodeCount];
            inStack = new bool[digraph.NodeCount];

            for (int v = 0; v < digraph.NodeCount; v++)
            {
                if (!visited[v])
                {
                    Dfs(digraph, v);
                }
            }
        }

        private bool Dfs(Digraph digraph, int s)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(s);
            visited[s] = true;

            while (stack.Count > 0)
            {
                int v = stack.Peek();
                stack.Pop();

                foreach (int w in digraph.Adjacent(v)) // 6 1 5 
                {
                    if (!visited[w])
                    {
                        stack.Push(w);
                        visited[s] = true;
                    }
                }
            }

            return true;
        }

        private void DfsRec(Digraph digraph, int v)
        {
            preOrder.Enqueue(v);
            visited[v] = true;

            foreach (int w in digraph.Adjacent(v)) // 6 1 5 
            {
                if (!visited[w])
                {
                    DfsRec(digraph, w);
                }
            }

            postOrder.Enqueue(v);
            reversePostOrder.Push(v);
        }

        public int[] PreOrder { get { return preOrder.ToArray(); } }
        public int[] PostOrder { get { return postOrder.ToArray(); } }
        public int[] ReversePostOrder { get { return reversePostOrder.ToArray(); } }
    }
}
