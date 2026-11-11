using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Generic
{
    // A generic priority queue built on a binary min-heap.
    // The item with the LOWEST priority number is dequeued first.
    // Items with the same priority leave in the order they were added.
    public class MinPriorityQueue<T>
    {
        private class HeapNode
        {
            public T Item;
            public int Priority;
            public long Order;
        }

        private readonly List<HeapNode> heap;
        private long insertCounter;

        public MinPriorityQueue()
        {
            heap = new List<HeapNode>();
            insertCounter = 0;
        }

        public int Count
        {
            get
            {
                return heap.Count;
            }
        }

        public void Enqueue(T item, int priority)
        {
            HeapNode node = new HeapNode();
            node.Item = item;
            node.Priority = priority;
            node.Order = insertCounter++;

            heap.Add(node);
            SiftUp(heap.Count - 1);
        }

        public T Dequeue()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException(
                    "The priority queue is empty.");
            }

            T result = heap[0].Item;

            int last = heap.Count - 1;
            heap[0] = heap[last];
            heap.RemoveAt(last);

            if (heap.Count > 0)
            {
                SiftDown(0);
            }

            return result;
        }

        public T Peek()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException(
                    "The priority queue is empty.");
            }

            return heap[0].Item;
        }

        // Returns the items in the order they are stored inside the heap
        // (level by level). Used to show how the heap looks in memory.
        public List<T> ToHeapArray()
        {
            List<T> items = new List<T>();

            foreach (HeapNode node in heap)
            {
                items.Add(node.Item);
            }

            return items;
        }

        // Returns every item in priority order WITHOUT changing this queue.
        public List<T> ToOrderedList()
        {
            MinPriorityQueue<T> copy = new MinPriorityQueue<T>();
            copy.heap.AddRange(heap);
            copy.insertCounter = insertCounter;

            List<T> ordered = new List<T>();

            while (copy.Count > 0)
            {
                ordered.Add(copy.Dequeue());
            }

            return ordered;
        }

        private bool IsHigherPriority(HeapNode a, HeapNode b)
        {
            if (a.Priority != b.Priority)
            {
                return a.Priority < b.Priority;
            }

            return a.Order < b.Order;
        }

        private void SiftUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;

                if (!IsHigherPriority(heap[index], heap[parent]))
                {
                    break;
                }

                Swap(index, parent);
                index = parent;
            }
        }

        private void SiftDown(int index)
        {
            while (true)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int best = index;

                if (left < heap.Count &&
                    IsHigherPriority(heap[left], heap[best]))
                {
                    best = left;
                }

                if (right < heap.Count &&
                    IsHigherPriority(heap[right], heap[best]))
                {
                    best = right;
                }

                if (best == index)
                {
                    break;
                }

                Swap(index, best);
                index = best;
            }
        }

        private void Swap(int i, int j)
        {
            HeapNode temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
