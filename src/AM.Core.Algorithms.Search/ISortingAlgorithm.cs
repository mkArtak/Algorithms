using System;

namespace AM.Core.Algorithms.Search
{
    public interface ISortingAlgorithm<T> where T : IComparable<T>
    {
        void Sort(T[] array);
    }
}
