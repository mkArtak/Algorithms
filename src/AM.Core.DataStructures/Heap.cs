using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Core.DataStructures
{
    public class Heap<T> where T : IComparable
    {
        private T[] items;

        public Heap(T[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            this.items = items;

            this.Heapify(this.items);
        }

        private void Heapify(T[] items)
        {
            int lastParentIndex = GetParentIndex(items.Length - 1);

            for (int i = lastParentIndex; i >= 0; i--)
            {
                FixTree(items, i);
                PrintCurrent(items);
            }
        }

        private void PrintCurrent(T[] items)
        {
            string value = String.Join(" ", items);
        }

        private void FixTree(T[] items, int parentIndex)
        {
            if (parentIndex < items.Length && IsHeapCriteriaMaintainedForParent(items, parentIndex))
            {
                return;
            }

            int leftIndex = GetLeftChildIndex(parentIndex);
            int rightIndex = GetRightChildIndex(parentIndex);

            bool hasLeftChildIndex = leftIndex < items.Length;
            bool hasRightChildIndex = rightIndex < items.Length;
            if (hasRightChildIndex && items[leftIndex].CompareTo(items[rightIndex]) < 0)
            {
                // Right child has bigger value than the left child
                // If it's bigger than the parent's value, then swap those
                if (items[rightIndex].CompareTo(items[parentIndex]) > 0)
                {
                    // Right child has bigger value than the parent.
                    // Swap those to maintain the heap criteria.
                    Swap(items, parentIndex, rightIndex);

                    // Right index has a new value. Fix the subtree.
                    FixTree(items, rightIndex);
                }
            }
            else if (hasLeftChildIndex)
            {
                // left child has bigger value than the right child
                // If it's bigger than the parent's value, then swap those
                if (items[leftIndex].CompareTo(items[parentIndex]) > 0)
                {
                    // Left child has bigger value than the parent.
                    // Swap those to maintain the heap criteria
                    Swap(items, parentIndex, leftIndex);

                    // Left index has a new value. Fix the subtree.
                    FixTree(items, leftIndex);
                }
            }
        }

        private static bool IsHeapCriteriaMaintainedForParent(T[] array, int parentIndex)
        {
            int leftIndex = GetLeftChildIndex(parentIndex);
            int rightIndex = GetRightChildIndex(parentIndex);

            bool hasLeftChild = leftIndex < array.Length;
            bool hasrightChild = rightIndex < array.Length;

            bool result = true;
            if ((hasLeftChild && array[parentIndex].CompareTo(array[leftIndex]) < 0) || (hasrightChild && array[parentIndex].CompareTo(array[rightIndex]) < 0))
            {
                result = false;
            }

            return result;
        }

        private static void Swap(T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        private static int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private static int GetRightChildIndex(int parentIndex)
        {
            return 2 * (parentIndex + 1);
        }

        private static int GetParentIndex(int childIndex)
        {
            return (int)Math.Floor((double)(childIndex - 1) / 2);
        }
    }
}
