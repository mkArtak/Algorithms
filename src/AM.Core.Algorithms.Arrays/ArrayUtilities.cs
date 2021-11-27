using System;
using System.Runtime.CompilerServices;

namespace AM.Core.Algorithms.Arrays
{
    public static class ArrayUtilities
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var nums1Noop = nums1 == null || nums1.Length == 0;
            var nums2Noop = nums2 == null || nums2.Length == 0;

            if (nums1Noop && nums2Noop)
            {
                throw new ArgumentException();
            }

            if (nums1Noop)
                return MedianOf(nums2);

            if (nums2Noop)
                return MedianOf(nums1);

            var sortedArray = MergeSortedArrays(nums1, nums2);
            return MedianOf(sortedArray);
        }

        public static double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            var nums1Noop = nums1 == null || nums1.Length == 0;
            var nums2Noop = nums2 == null || nums2.Length == 0;

            if (nums1Noop && nums2Noop)
            {
                throw new ArgumentException();
            }

            if (nums1Noop)
                return MedianOf(nums2);

            if (nums2Noop)
                return MedianOf(nums1);

            var (index1, index2) = FindMedianIndicies(nums1.Length + nums2.Length);
            var (val1, val2) = GetValuesInMergedArrayAt(nums1, nums2, index1, index2);

            return (double)(val1 + val2) / 2;
        }

        private static (int, int) GetValuesInMergedArrayAt(int[] nums1, int[] nums2, int leftIndex, int rightIndex)
        {
            int val1 = -1, val2 = -1;

            int index1 = 0;
            int index2 = 0;

            for (var resultIndex = 0; resultIndex <= rightIndex; resultIndex++)
            {
                if (index1 < nums1.Length && index2 < nums2.Length)
                {
                    if (nums1[index1] < nums2[index2])
                    {
                        StoreIfLeftOrRight(nums1[index1++], resultIndex, leftIndex, rightIndex, ref val1, ref val2);
                    }
                    else
                    {
                        StoreIfLeftOrRight(nums2[index2++], resultIndex, leftIndex, rightIndex, ref val1, ref val2);
                    }
                }
                else if (index1 < nums1.Length)
                {
                    StoreIfLeftOrRight(nums1[index1++], resultIndex, leftIndex, rightIndex, ref val1, ref val2);
                }
                else
                {
                    StoreIfLeftOrRight(nums2[index2++], resultIndex, leftIndex, rightIndex, ref val1, ref val2);
                }
            }

            return (val1, val2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void StoreIfLeftOrRight(int value, int resultIndex, int leftIndex, int rightIndex, ref int val1, ref int val2)
        {
            if (resultIndex == leftIndex)
            {
                val1 = value;
                if (leftIndex == rightIndex)
                    val2 = val1;
            }
            else if (resultIndex == rightIndex)
                val2 = value;
        }

        private static double MedianOf(int[] array)
        {
            var (leftIndex, rightIndex) = FindMedianIndicies(array.Length);

            return (double)(array[leftIndex] + array[rightIndex]) / 2;
        }

        private static (int, int) FindMedianIndicies(int length)
        {
            if (length == 1)
                return (0, 0);

            int leftIndex = (int)(length / 2);
            int rightIndex = leftIndex;
            if (length % 2 == 0)
                leftIndex--;

            return (leftIndex, rightIndex);
        }

        private static int[] MergeSortedArrays(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length + nums2.Length];

            int index1 = 0;
            int index2 = 0;

            for (var resultIndex = 0; resultIndex < result.Length; resultIndex++)
            {
                int valueToStore;

                if (index1 < nums1.Length && index2 < nums2.Length)
                {
                    if (nums1[index1] < nums2[index2])
                    {
                        valueToStore = nums1[index1++];
                    }
                    else
                    {
                        valueToStore = nums2[index2++];
                    }
                }
                else if (index1 < nums1.Length)
                {
                    valueToStore = nums1[index1++];
                }
                else
                {
                    valueToStore = nums2[index2++];
                }

                result[resultIndex] = valueToStore;
            }

            return result;
        }
    }
}
