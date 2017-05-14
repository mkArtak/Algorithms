using System;

namespace AM.Core.DataStructures
{
    public class Heap<T> where T : IComparable<T>
    {
        private readonly T[] items;
        private readonly HeapTypes heapType;


        /// <summary>
        /// Gets the value of the root element of the heap.
        /// </summary>
        /// <exception cref="Exception">Thrown, when the heap has no elements.</exception>
        public T Root
        {
            get
            {
                if (this.items.Length == 0)
                {
                    throw new Exception("Heap has no elements");
                }

                return this.items[0];
            }
        }

        public Heap(T[] items, HeapTypes type)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            this.heapType = type;
            this.items = items;
            this.Heapify();
        }

        private void Heapify()
        {
            Func<T[], int, int?> heapifyLogic = GetHeapifyLogic();
            int lastParentIndex = GetParentIndex(this.items.Length - 1);
            for (int i = lastParentIndex; i >= 0; i--)
            {
                Heapify(this.items, i, heapifyLogic);
            }
        }

        private Func<T[], int, int?> GetHeapifyLogic()
        {
            Func<T[], int, int?> heapifyLogic;
            switch (this.heapType)
            {
                case HeapTypes.MaxHeap:
                    heapifyLogic = IdentifyChildIndexMaxHeapify;
                    break;

                case HeapTypes.Minheap:
                    heapifyLogic = IdentifyChildIndexMinHeapify;
                    break;

                default:
                    throw new Exception("Non-supported heap type");
            }

            return heapifyLogic;
        }

        private static void Heapify(T[] items, int parentIndex, Func<T[], int, int?> swapLogic)
        {
            do
            {
                // A null value indicates that there is no swap required on current level.
                int? childIndexToSwapRootWith = swapLogic(items, parentIndex);

                if (!childIndexToSwapRootWith.HasValue)
                {
                    break;
                }

                Swap(items, parentIndex, childIndexToSwapRootWith.Value);
                parentIndex = childIndexToSwapRootWith.Value;
            } while (true);
        }

        private static int? IdentifyChildIndexMaxHeapify(T[] items, int parentIndex)
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

        private static int? IdentifyChildIndexMinHeapify(T[] items, int parentIndex)
        {
            int? childIndexToSwapRootWith = null;

            int leftIndex = GetLeftChildIndex(parentIndex);
            int rightIndex = GetRightChildIndex(parentIndex);

            if (rightIndex < items.Length && items[leftIndex].CompareTo(items[rightIndex]) < 0)
            {
                // Right child has bigger value than the left child
                // If it's bigger than the parent's value, then swap those
                if (items[rightIndex].CompareTo(items[parentIndex]) < 0)
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
