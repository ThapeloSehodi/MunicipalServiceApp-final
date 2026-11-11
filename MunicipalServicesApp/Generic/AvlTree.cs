using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Generic
{
    // An AVL tree: a binary search tree that keeps itself balanced.
    // After every insert, the heights of the two sides of any node
    // differ by at most 1. Rotations restore the balance when needed,
    // so searching always takes O(log n) steps.
    public class AvlTree<TKey, TValue> : SearchTreeBase<TKey, TValue>
    {
        public int RotationCount { get; private set; }

        public AvlTree()
            : base(null)
        {
        }

        public AvlTree(IComparer<TKey> keyComparer)
            : base(keyComparer)
        {
        }

        public override void Insert(TKey key, TValue value)
        {
            root = Insert(root, key, value);
        }

        // Balance factor = height of left side - height of right side.
        public int GetBalanceFactor(TKey key)
        {
            Node node = FindNode(key);

            return node == null ? 0 : Balance(node);
        }

        private Node Insert(Node node, TKey key, TValue value)
        {
            if (node == null)
            {
                Count++;
                return new Node(key, value);
            }

            int result = comparer.Compare(key, node.Key);

            if (result < 0)
            {
                node.Left = Insert(node.Left, key, value);
            }
            else if (result > 0)
            {
                node.Right = Insert(node.Right, key, value);
            }
            else
            {
                node.Value = value;
                return node;
            }

            UpdateHeight(node);

            int balance = Balance(node);

            // Left-Left case
            if (balance > 1 && comparer.Compare(key, node.Left.Key) < 0)
            {
                return RotateRight(node);
            }

            // Right-Right case
            if (balance < -1 && comparer.Compare(key, node.Right.Key) > 0)
            {
                return RotateLeft(node);
            }

            // Left-Right case
            if (balance > 1 && comparer.Compare(key, node.Left.Key) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // Right-Left case
            if (balance < -1 && comparer.Compare(key, node.Right.Key) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        private int HeightOf(Node node)
        {
            return node == null ? 0 : node.Height;
        }

        private void UpdateHeight(Node node)
        {
            node.Height = 1 + Math.Max(HeightOf(node.Left), HeightOf(node.Right));
        }

        private int Balance(Node node)
        {
            return node == null ? 0 : HeightOf(node.Left) - HeightOf(node.Right);
        }

        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node middle = x.Right;

            x.Right = y;
            y.Left = middle;

            UpdateHeight(y);
            UpdateHeight(x);
            RotationCount++;

            return x;
        }

        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node middle = y.Left;

            y.Left = x;
            x.Right = middle;

            UpdateHeight(x);
            UpdateHeight(y);
            RotationCount++;

            return y;
        }
    }
}
