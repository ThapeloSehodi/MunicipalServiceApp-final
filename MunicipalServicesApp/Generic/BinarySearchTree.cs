using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Generic
{
    // A binary search tree: smaller keys go left, larger keys go right.
    // It is NOT balanced, so sorted input can make it as tall as a list.
    public class BinarySearchTree<TKey, TValue> : SearchTreeBase<TKey, TValue>
    {
        public BinarySearchTree()
            : base(null)
        {
        }

        public BinarySearchTree(IComparer<TKey> keyComparer)
            : base(keyComparer)
        {
        }

        public override void Insert(TKey key, TValue value)
        {
            if (root == null)
            {
                root = new Node(key, value);
                Count++;
                return;
            }

            Node current = root;

            while (true)
            {
                int result = comparer.Compare(key, current.Key);

                if (result == 0)
                {
                    current.Value = value;
                    return;
                }

                if (result < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node(key, value);
                        Count++;
                        return;
                    }

                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node(key, value);
                        Count++;
                        return;
                    }

                    current = current.Right;
                }
            }
        }
    }
}
