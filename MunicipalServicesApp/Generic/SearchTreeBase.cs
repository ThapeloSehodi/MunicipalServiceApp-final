using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Generic
{
    // Shared code for the three search trees (BST, AVL and Red-Black).
    // The subclasses only differ in HOW they insert and keep the tree balanced.
    public abstract class SearchTreeBase<TKey, TValue>
    {
        protected class Node
        {
            public TKey Key;
            public TValue Value;
            public Node Left;
            public Node Right;

            // Used by the AVL tree
            public int Height = 1;

            // Used by the Red-Black tree
            public bool IsRed;

            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        protected Node root;
        protected readonly IComparer<TKey> comparer;

        public int Count { get; protected set; }

        // How many keys were compared during the last search.
        public int LastSearchComparisons { get; private set; }

        protected SearchTreeBase(IComparer<TKey> keyComparer)
        {
            comparer = keyComparer ?? Comparer<TKey>.Default;
        }

        public abstract void Insert(TKey key, TValue value);

        public bool TryGetValue(TKey key, out TValue value)
        {
            LastSearchComparisons = 0;
            Node current = root;

            while (current != null)
            {
                LastSearchComparisons++;
                int result = comparer.Compare(key, current.Key);

                if (result == 0)
                {
                    value = current.Value;
                    return true;
                }

                current = result < 0 ? current.Left : current.Right;
            }

            value = default(TValue);
            return false;
        }

        public int Height()
        {
            return Height(root);
        }

        private int Height(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        // The smallest possible height for this many nodes: ceil(log2(n + 1))
        public int MinimumPossibleHeight()
        {
            return (int)Math.Ceiling(Math.Log(Count + 1, 2));
        }

        public List<TKey> InOrderKeys()
        {
            List<TKey> keys = new List<TKey>();
            InOrder(root, node => keys.Add(node.Key));

            return keys;
        }

        public List<TValue> InOrderValues()
        {
            List<TValue> values = new List<TValue>();
            InOrder(root, node => values.Add(node.Value));

            return values;
        }

        public List<TKey> PreOrderKeys()
        {
            List<TKey> keys = new List<TKey>();
            PreOrder(root, node => keys.Add(node.Key));

            return keys;
        }

        public List<TKey> PostOrderKeys()
        {
            List<TKey> keys = new List<TKey>();
            PostOrder(root, node => keys.Add(node.Key));

            return keys;
        }

        public List<TKey> LevelOrderKeys()
        {
            List<TKey> keys = new List<TKey>();

            if (root == null)
            {
                return keys;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                keys.Add(node.Key);

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            return keys;
        }

        // All values whose key is between low and high (both included).
        // Whole branches that cannot contain a match are skipped.
        public List<TValue> Range(TKey low, TKey high)
        {
            List<TValue> result = new List<TValue>();
            Range(root, low, high, result);

            return result;
        }

        private void Range(Node node, TKey low, TKey high, List<TValue> result)
        {
            if (node == null)
            {
                return;
            }

            int compareLow = comparer.Compare(low, node.Key);
            int compareHigh = comparer.Compare(high, node.Key);

            if (compareLow < 0)
            {
                Range(node.Left, low, high, result);
            }

            if (compareLow <= 0 && compareHigh >= 0)
            {
                result.Add(node.Value);
            }

            if (compareHigh > 0)
            {
                Range(node.Right, low, high, result);
            }
        }

        public bool IsRedNode(TKey key)
        {
            Node node = FindNode(key);

            return node != null && node.IsRed;
        }

        protected Node FindNode(TKey key)
        {
            Node current = root;

            while (current != null)
            {
                int result = comparer.Compare(key, current.Key);

                if (result == 0)
                {
                    return current;
                }

                current = result < 0 ? current.Left : current.Right;
            }

            return null;
        }

        private void InOrder(Node node, Action<Node> visit)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.Left, visit);
            visit(node);
            InOrder(node.Right, visit);
        }

        private void PreOrder(Node node, Action<Node> visit)
        {
            if (node == null)
            {
                return;
            }

            visit(node);
            PreOrder(node.Left, visit);
            PreOrder(node.Right, visit);
        }

        private void PostOrder(Node node, Action<Node> visit)
        {
            if (node == null)
            {
                return;
            }

            PostOrder(node.Left, visit);
            PostOrder(node.Right, visit);
            visit(node);
        }
    }
}
