using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Generic
{
    // A left-leaning red-black tree. Every node is red or black and:
    //   1. The root is black.
    //   2. A red node never has a red child.
    //   3. Every path from the root to an empty spot has the same
    //      number of black nodes.
    // These rules keep the tree balanced (height at most 2 x log2(n)),
    // using fewer rotations than an AVL tree.
    public class RedBlackTree<TKey, TValue> : SearchTreeBase<TKey, TValue>
    {
        public int RotationCount { get; private set; }

        public int ColourFlipCount { get; private set; }

        public RedBlackTree()
            : base(null)
        {
        }

        public RedBlackTree(IComparer<TKey> keyComparer)
            : base(keyComparer)
        {
        }

        public override void Insert(TKey key, TValue value)
        {
            root = Insert(root, key, value);
            root.IsRed = false;
        }

        private Node Insert(Node node, TKey key, TValue value)
        {
            if (node == null)
            {
                Count++;

                Node created = new Node(key, value);
                created.IsRed = true;

                return created;
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
            }

            // Repair any broken red-black rules on the way back up.
            if (IsRed(node.Right) && !IsRed(node.Left))
            {
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColours(node);
            }

            return node;
        }

        private bool IsRed(Node node)
        {
            return node != null && node.IsRed;
        }

        private Node RotateLeft(Node node)
        {
            Node x = node.Right;

            node.Right = x.Left;
            x.Left = node;
            x.IsRed = node.IsRed;
            node.IsRed = true;
            RotationCount++;

            return x;
        }

        private Node RotateRight(Node node)
        {
            Node x = node.Left;

            node.Left = x.Right;
            x.Right = node;
            x.IsRed = node.IsRed;
            node.IsRed = true;
            RotationCount++;

            return x;
        }

        private void FlipColours(Node node)
        {
            node.IsRed = true;
            node.Left.IsRed = false;
            node.Right.IsRed = false;
            ColourFlipCount++;
        }
    }
}
