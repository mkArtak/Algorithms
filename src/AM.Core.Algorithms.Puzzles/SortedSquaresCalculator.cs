using System.Collections.Generic;

namespace AM.Core.Algorithms.Puzzles
{
    public class SortedSquaresCalculator
    {
        public static int[] SortedSquares(int[] A)
        {
            if (A.Length == 1)
                return new int[] { A[0] * A[0] };

            int i = 0;
            int[] result = new int[A.Length];
            int resultIndex = 0;

            if (A[0] >= 0)
            {
                while (resultIndex < A.Length)
                {
                    result[resultIndex++] = A[i] * A[i++];
                }
            }
            else
            {
                IList<int> sortedNegatives = new List<int>();
                while (i < A.Length && A[i] < 0)
                {
                    sortedNegatives.Insert(0, -A[i]);
                    i++;
                }

                if (i < A.Length)
                {
                    // Some positive elements are still left.
                    // Merge these two sorted lists together

                    int negIndex = 0;
                    while (resultIndex < A.Length)
                    {
                        if (A[i] <= sortedNegatives[negIndex])
                        {
                            result[resultIndex] = A[i] * A[i];
                            i++;
                            resultIndex++;

                            if (i == A.Length)
                            {
                                // We have run out of positive list
                                // Fill in negatives as is
                                while (resultIndex < A.Length)
                                {
                                    result[resultIndex] = sortedNegatives[negIndex] * sortedNegatives[negIndex];
                                    negIndex++;
                                    resultIndex++;
                                }
                                break;
                            }
                        }
                        else
                        {
                            result[resultIndex] = sortedNegatives[negIndex] * sortedNegatives[negIndex];
                            negIndex++;

                            resultIndex++;

                            if (negIndex == sortedNegatives.Count)
                            {
                                // We have run out of negative list
                                // Fill in positives as is
                                while (resultIndex < A.Length)
                                {
                                    result[resultIndex] = A[i] * A[i];
                                    i++;
                                    resultIndex++;
                                }

                                break;
                            }
                        }
                    }
                }
            }

            return result;
        }

    }
}
