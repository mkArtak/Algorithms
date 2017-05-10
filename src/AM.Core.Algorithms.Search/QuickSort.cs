using System;

namespace AM.Core.Algorithms.Search
{
    /// <summary>
    /// Represents an implementation of QuickSort algorithm.
    /// </summary>
    public static class QuickSort
    {
        /// <summary>
        /// Sorts the elements of the specified array using the quicksort algorithm.
        /// </summary>
        /// <param name="array"></param>
        public static void Sort(int[] array)
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
        private static void Sort(int[] array, int startIndex, int endIndex)
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
        private static int FindFixedIndex(int[] array, int startIndex, int endIndex)
        {
            int pivot = array[startIndex];
            int i = startIndex - 1;
            int j = endIndex + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (array[i] < pivot);

                do
                {
                    j--;
                } while (array[j] > pivot);

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
        private static void Swap(int[] array, int index1, int index2)
        {
            if (index1 != index2)
            {
                int val = array[index1];
                array[index1] = array[index2];
                array[index2] = val;
            }
        }
    }
}
