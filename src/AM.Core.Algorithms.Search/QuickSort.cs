using System;

namespace AM.Core.Algorithms.Search
{
    /// <summary>
    /// Represents an implementation of QuickSort algorithm.
    /// </summary>
    public class QuickSort<T> : ISortingAlgorithm<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the elements of the specified array using the quicksort algorithm.
        /// </summary>
        /// <param name="array"></param>
        public void Sort(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Sort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Sorts the specified range of the given array.
        /// </summary>
        /// <param name="array">The array which for the specified range of elements should be sorted.</param>
        /// <param name="startIndex">The index of the elemnet specifying the beginning of the range.</param>
        /// <param name="endIndex">The index of the element specifying the end of the range.</param>
        private static void Sort(T[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int fixedIndex = FindFixedIndex(array, startIndex, endIndex);
            Sort(array, startIndex, fixedIndex);
            Sort(array, fixedIndex + 1, endIndex);
        }

        /// <summary>
        /// Finds a pivot element in the specified range of the given array.
        /// </summary>
        /// <param name="array">The array in which the pivot is being searched for.</param>
        /// <param name="startIndex">The start index of the sub-array, to start search from.</param>
        /// <param name="endIndex">The end index of the sub-array, to end the search at.</param>
        /// <returns></returns>
        private static int FindFixedIndex(T[] array, int startIndex, int endIndex)
        {
            T pivot = array[startIndex];
            int i = startIndex - 1;
            int j = endIndex + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (array[i].CompareTo(pivot) < 0);

                do
                {
                    j--;
                } while (array[j].CompareTo(pivot) > 0);

                if (i >= j)
                {
                    return j;
                }

                Swap(array, i, j);
            }
        }

        /// <summary>
        /// Swaps the specified two indecies in the specified array.
        /// </summary>
        /// <param name="array">The array, to swap elements in.</param>
        /// <param name="index1">The first element to swap with the second one.</param>
        /// <param name="index2">The second element to swap with first one.</param>
        private static void Swap(T[] array, int index1, int index2)
        {
            if (index1 != index2)
            {
                T val = array[index1];
                array[index1] = array[index2];
                array[index2] = val;
            }
        }
    }
}
