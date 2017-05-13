using System;

namespace AM.Core.Algorithms.Search
{
    public class MergeSort<T> : ISortingAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(T[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int separatorIndex = startIndex + (endIndex - startIndex) / 2;
            Sort(array, startIndex, separatorIndex);
            Sort(array, separatorIndex + 1, endIndex);
            Merge(array, startIndex, separatorIndex, endIndex);
        }

        private static void Merge(T[] array, int startIndex, int separatorIndex, int endIndex)
        {
            int firstArrayLength = separatorIndex - startIndex + 1;
            int secondArrayLength = endIndex - separatorIndex;

            T[] firstArray = new T[firstArrayLength];
            T[] secondArray = new T[secondArrayLength];

            for (int i = 0; i < firstArrayLength; i++)
            {
                firstArray[i] = array[startIndex + i];
            }

            for (int j = 0; j < secondArrayLength; j++)
            {
                secondArray[j] = array[separatorIndex + j + 1];
            }

            int firstArrayIndex = 0;
            int secondArrayIndex = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (firstArrayIndex == firstArray.Length)
                {
                    // No more elements in the first array
                    array[i] = secondArray[secondArrayIndex++];
                }
                else if (secondArrayIndex == secondArray.Length)
                {
                    // No more elements in the second array
                    array[i] = firstArray[firstArrayIndex++];
                }
                else
                {
                    array[i] = firstArray[firstArrayIndex].CompareTo(secondArray[secondArrayIndex]) <= 0 ? firstArray[firstArrayIndex++] : secondArray[secondArrayIndex++];
                }
            }
        }
    }
}