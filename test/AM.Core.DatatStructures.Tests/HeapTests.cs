using Xunit;

namespace AM.Core.DataStructures.Tests
{
    public class HeapTests
    {
        [Fact]
        public void MaxHeapHasMaxInTheRoot()
        {
            int[] items = new[] { 1, 2, 3, 4, 5, 6, 7, 7, 8 };

            Heap<int> sut = new Heap<int>(items, HeapTypes.MaxHeap);

            Assert.Equal(8, sut.Root);
        }

        [Fact]
        public void MinHeapHasMinInTheRoot()
        {
            int[] items = new[] { 1, 2, 3, 4, 5, 6, 7, 7, 8 };

            Heap<int> sut = new Heap<int>(items, HeapTypes.Minheap);

            Assert.Equal(1, sut.Root);
        }
    }
}
