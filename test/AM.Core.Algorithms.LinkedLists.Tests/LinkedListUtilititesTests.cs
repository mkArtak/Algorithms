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

        [Fact]
        public void SwapNodesInPairs_Succeeds()
        {
            int[] nodes = new[] { 1, 2, 3, 4 };
            int[] expectedResult = new int[] { 2, 1, 4, 3 };

            ListNode root = ToLinkedList(nodes);

            var actualResult = LinkedListUtilities.SwapNodesInPairs(root);
            Assert.Equal<int>(expectedResult, ToArray(actualResult));
        }

        [Fact]
        public void SwapNodesInPairs_SucceedsForOddNodes()
        {
            int[] nodes = new[] { 1, 2, 3};
            int[] expectedResult = new int[] { 2, 1, 3 };

            ListNode root = ToLinkedList(nodes);

            var actualResult = LinkedListUtilities.SwapNodesInPairs(root);
            Assert.Equal<int>(expectedResult, ToArray(actualResult));
        }

        [Fact]
        public void SwapNodesInPairs_SwapsOnlyTwoNodes()
        {
            int[] nodes = new[] { 1, 2 };
            int[] expectedResult = new int[] { 2, 1 };
            ListNode root = ToLinkedList(nodes);

            var actualResult = LinkedListUtilities.SwapNodesInPairs(root);
            Assert.Equal<int>(expectedResult, ToArray(actualResult));
        }

        [Fact]
        public void SwapNodesInPairs_ReturnsRootForSingleNodeList()
        {
            ListNode node = new ListNode(7);
            ListNode swapped = LinkedListUtilities.SwapNodesInPairs(node);
            Assert.Null(swapped.next);
            Assert.Equal(node, swapped);
        }

        [Fact]
        public void SwapNodesInPairs_ReturnsNullForNullNode()
        {
            Assert.Null(LinkedListUtilities.SwapNodesInPairs(null));
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
