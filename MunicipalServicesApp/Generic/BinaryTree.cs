using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Generic
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }
    }

    // A plain binary tree: every node has at most two children.
    // New values are placed in the first free position, level by level,
    // so the tree is always complete. There is no ordering of values.
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public int Count { get; private set; }

        public void Insert(T value)
        {
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(value);
            Count++;

            if (Root == null)
            {
                Root = node;
                return;
            }

            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                BinaryTreeNode<T> current = queue.Dequeue();

                if (current.Left == null)
                {
                    current.Left = node;
                    return;
                }

                queue.Enqueue(current.Left);

                if (current.Right == null)
                {
                    current.Right = node;
                    return;
                }

                queue.Enqueue(current.Right);
            }
        }

        public int Height()
        {
            return Height(Root);
        }

        private int Height(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        // Left, node, right
        public List<T> InOrder()
        {
            List<T> result = new List<T>();
            InOrder(Root, result);

            return result;
        }

        private void InOrder(BinaryTreeNode<T> node, List<T> result)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.Left, result);
            result.Add(node.Value);
            InOrder(node.Right, result);
        }

        // Node, left, right
        public List<T> PreOrder()
        {
            List<T> result = new List<T>();
            PreOrder(Root, result);

            return result;
        }

        private void PreOrder(BinaryTreeNode<T> node, List<T> result)
        {
            if (node == null)
            {
                return;
            }

            result.Add(node.Value);
            PreOrder(node.Left, result);
            PreOrder(node.Right, result);
        }

        // Left, right, node
        public List<T> PostOrder()
        {
            List<T> result = new List<T>();
            PostOrder(Root, result);

            return result;
        }

        private void PostOrder(BinaryTreeNode<T> node, List<T> result)
        {
            if (node == null)
            {
                return;
            }

            PostOrder(node.Left, result);
            PostOrder(node.Right, result);
            result.Add(node.Value);
        }

        // One level at a time
        public List<T> LevelOrder()
        {
            List<T> result = new List<T>();

            if (Root == null)
            {
                return result;
            }

            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                BinaryTreeNode<T> node = queue.Dequeue();
                result.Add(node.Value);

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            return result;
        }
    }
}
