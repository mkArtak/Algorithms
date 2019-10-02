using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AM.Core.Algorithms.LinkedLists.Tests
{
    public class LinkedListUtilitiesTests
    {
        [Fact]
        public void RemoveNthFromEnd_ForMidElement()
        {
            int[] input = new[] { 1, 2, 3, 4, 5 };
            int[] expectedResult = new[] { 1, 2, 3, 5 };

            var actualResult = LinkedListUtilities.RemoveNthFromEnd(ToLinkedList(input), 2);

            var actualArray = ToArray(actualResult);
            Assert.Equal(expectedResult, actualArray);
        }

        [Fact]
        public void RemoveNthFromEnd_SucceedsForSingleElementInput()
        {
            int[] input = new[] { 1 };
            int[] expectedResult = new int[] { };

            var actualResult = LinkedListUtilities.RemoveNthFromEnd(ToLinkedList(input), 1);

            var actualArray = ToArray(actualResult);
            Assert.Equal(expectedResult, actualArray);
        }

        [Fact]
        public void RemoveNthFromEnd_RemovalOfTheFirstElement()
        {
            int[] input = new[] { 1, 2 };
            int[] expectedResult = new int[] { 2 };

            var actualResult = LinkedListUtilities.RemoveNthFromEnd(ToLinkedList(input), 2);

            var actualArray = ToArray(actualResult);
            Assert.Equal(expectedResult, actualArray);
        }

        private static ListNode ToLinkedList(int[] input)
        {
            ListNode root = new ListNode(input[0]);
            ListNode current = root;
            for (int i = 1; i < input.Length; i++)
            {
                current.next = new ListNode(input[i]);
                current = current.next;
            }

            return root;
        }

        private static int[] ToArray(ListNode root)
        {
            IList<int> result = new List<int>();

            while (root != null)
            {
                result.Add(root.val);
                root = root.next;
            }

            return result.ToArray();
        }
    }
}
