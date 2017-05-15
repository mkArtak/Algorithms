using AM.Core.DataStructures;
using System;

namespace AM.Core.Algorithms.Search
{
    public class HeapSort<T> : ISortingAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Heap<T> heap = new Heap<T>(array, HeapTypes.MaxHeap);
            for (int i = 0; i < array.Length; i++)
            {
                T max = heap.ExtractRoot();
            }
        }
    }
}
