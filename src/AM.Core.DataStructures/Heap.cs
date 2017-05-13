using System;

namespace AM.Core.DataStructures
{
    public class Heap<T> where T : IComparable<T>
    {
        private readonly T[] items;

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
                MaxHeapify(items, i);
            }
        }

        private void MaxHeapify(T[] items, int parentIndex)
        {
            do
            {
                // A null value indicates that there is no swap required on current level.
                int? childIndexToSwapRootWith = GetChildIndexToSwapWithParent(items, parentIndex);

                if (!childIndexToSwapRootWith.HasValue)
                {
                    break;
                }

                Swap(items, parentIndex, childIndexToSwapRootWith.Value);
                parentIndex = childIndexToSwapRootWith.Value;
            } while (true);
        }

        private static int? GetChildIndexToSwapWithParent(T[] items, int parentIndex)
        {
            int? childIndexToSwapRootWith = null;

            int leftIndex = GetLeftChildIndex(parentIndex);
            int rightIndex = GetRightChildIndex(parentIndex);

            if (rightIndex < items.Length && items[leftIndex].CompareTo(items[rightIndex]) < 0)
            {
                // Right child has bigger value than the left child
                // If it's bigger than the parent's value, then swap those
                if (items[rightIndex].CompareTo(items[parentIndex]) > 0)
                {
                    childIndexToSwapRootWith = rightIndex;
                }
            }
            else if (leftIndex < items.Length)
            {
                // left child has bigger value than the right child
                // If it's bigger than the parent's value, then swap those
                if (items[leftIndex].CompareTo(items[parentIndex]) > 0)
                {
                    childIndexToSwapRootWith = leftIndex;
                }
            }

            return childIndexToSwapRootWith;
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
