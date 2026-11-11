using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Generic
{
    // A node of a general (basic) tree: it can have any number of children.
    public class GeneralTreeNode<T>
    {
        public T Value { get; set; }

        public GeneralTreeNode<T> Parent { get; private set; }

        public List<GeneralTreeNode<T>> Children { get; private set; }

        public GeneralTreeNode(T value)
        {
            Value = value;
            Children = new List<GeneralTreeNode<T>>();
        }

        public bool IsLeaf
        {
            get
            {
                return Children.Count == 0;
            }
        }

        public GeneralTreeNode<T> AddChild(T value)
        {
            GeneralTreeNode<T> child = new GeneralTreeNode<T>(value);
            child.Parent = this;
            Children.Add(child);

            return child;
        }
    }

    // A general tree. In this application it models the municipal
    // department hierarchy: Municipality -> Department -> Category.
    public class GeneralTree<T>
    {
        public GeneralTreeNode<T> Root { get; private set; }

        public GeneralTree(T rootValue)
        {
            Root = new GeneralTreeNode<T>(rootValue);
        }

        public int Count()
        {
            return PreOrder().Count;
        }

        public int Height()
        {
            return Height(Root);
        }

        private int Height(GeneralTreeNode<T> node)
        {
            int tallest = 0;

            foreach (GeneralTreeNode<T> child in node.Children)
            {
                tallest = Math.Max(tallest, Height(child));
            }

            return tallest + 1;
        }

        // Depth-first: a node is visited before its children.
        public List<T> PreOrder()
        {
            List<T> result = new List<T>();
            PreOrder(Root, result);

            return result;
        }

        private void PreOrder(GeneralTreeNode<T> node, List<T> result)
        {
            result.Add(node.Value);

            foreach (GeneralTreeNode<T> child in node.Children)
            {
                PreOrder(child, result);
            }
        }

        // Breadth-first: one level at a time, using a queue.
        public List<T> LevelOrder()
        {
            List<T> result = new List<T>();
            Queue<GeneralTreeNode<T>> queue = new Queue<GeneralTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                GeneralTreeNode<T> node = queue.Dequeue();
                result.Add(node.Value);

                foreach (GeneralTreeNode<T> child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public GeneralTreeNode<T> Find(Predicate<T> match)
        {
            return Find(Root, match);
        }

        private GeneralTreeNode<T> Find(GeneralTreeNode<T> node, Predicate<T> match)
        {
            if (match(node.Value))
            {
                return node;
            }

            foreach (GeneralTreeNode<T> child in node.Children)
            {
                GeneralTreeNode<T> found = Find(child, match);

                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }

        // The values of all leaves at or below a node.
        public List<T> GetLeafValues(GeneralTreeNode<T> start)
        {
            List<T> leaves = new List<T>();
            CollectLeaves(start, leaves);

            return leaves;
        }

        private void CollectLeaves(GeneralTreeNode<T> node, List<T> leaves)
        {
            if (node.IsLeaf)
            {
                leaves.Add(node.Value);
                return;
            }

            foreach (GeneralTreeNode<T> child in node.Children)
            {
                CollectLeaves(child, leaves);
            }
        }
    }
}
