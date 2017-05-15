using System;

namespace AM.Core.DataStructures
{
    public class Heap<T> where T : IComparable<T>
    {
        private readonly T[] items;
        private int size;
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
            this.size = this.items.Length;
            this.Heapify();
        }

        public T ExtractRoot()
        {
            T result = this.Root;

            Swap(0, this.size - 1);
            this.size--;
            this.Heapify();

            return result;
        }

        private void Heapify()
        {
            Func<int, int?> heapifyLogic = GetHeapifyLogic();
            int lastParentIndex = GetParentIndex(this.size - 1);
            for (int i = lastParentIndex; i >= 0; i--)
            {
                Heapify(i, heapifyLogic);
            }
        }

        private Func<int, int?> GetHeapifyLogic()
        {
            Func<int, int?> heapifyLogic;
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

        private void Heapify(int parentIndex, Func<int, int?> swapLogic)
        {
            do
            {
                // A null value indicates that there is no swap required on current level.
                int? childIndexToSwapRootWith = swapLogic(parentIndex);

                if (!childIndexToSwapRootWith.HasValue)
                {
                    break;
                }

                Swap(parentIndex, childIndexToSwapRootWith.Value);
                parentIndex = childIndexToSwapRootWith.Value;
            } while (true);
        }

        private int? IdentifyChildIndexMaxHeapify(int parentIndex)
        {
            int? childIndexToSwapRootWith = null;

            int leftIndex = GetLeftChildIndex(parentIndex);
            int rightIndex = GetRightChildIndex(parentIndex);

            if (rightIndex < this.size && this.items[leftIndex].CompareTo(this.items[rightIndex]) < 0)
            {
                // Right child has bigger value than the left child
                // If it's bigger than the parent's value, then swap those
                if (this.items[rightIndex].CompareTo(this.items[parentIndex]) > 0)
                {
                    childIndexToSwapRootWith = rightIndex;
                }
            }
            else if (leftIndex < this.size)
            {
                // left child has bigger value than the right child
                // If it's bigger than the parent's value, then swap those
                if (this.items[leftIndex].CompareTo(this.items[parentIndex]) > 0)
                {
                    childIndexToSwapRootWith = leftIndex;
                }
            }

            return childIndexToSwapRootWith;
        }

        private int? IdentifyChildIndexMinHeapify(int parentIndex)
        {
            int? childIndexToSwapRootWith = null;

            int leftIndex = GetLeftChildIndex(parentIndex);
            int rightIndex = GetRightChildIndex(parentIndex);

            if (rightIndex < this.size && this.items[leftIndex].CompareTo(this.items[rightIndex]) > 0)
            {
                // Right child has bigger value than the left child
                // If it's bigger than the parent's value, then swap those
                if (this.items[rightIndex].CompareTo(this.items[parentIndex]) < 0)
                {
                    childIndexToSwapRootWith = rightIndex;
                }
            }
            else if (leftIndex < this.size)
            {
                // left child has bigger value than the right child
                // If it's bigger than the parent's value, then swap those
                if (this.items[leftIndex].CompareTo(this.items[parentIndex]) < 0)
                {
                    childIndexToSwapRootWith = leftIndex;
                }
            }

            return childIndexToSwapRootWith;
        }

        private void Swap(int index1, int index2)
        {
            T temp = this.items[index1];
            this.items[index1] = this.items[index2];
            this.items[index2] = temp;
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
