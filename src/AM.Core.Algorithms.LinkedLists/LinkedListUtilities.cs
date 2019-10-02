using System;

namespace AM.Core.Algorithms.LinkedLists
{
    public static class LinkedListUtilities
    {
        /// <summary>
        /// Removes the n-th element from the end of the given linked-list.
        /// </summary>
        /// <param name="head">The head of the linked-list</param>
        /// <param name="n">1-based index of the element to be removed from the end of the linked list.</param>
        /// <returns>The head of the linkedList which has the specified node removed</returns>
        /// <remarks>This is the solution for the https://leetcode.com/problems/remove-nth-node-from-end-of-list/ problem</remarks>
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (n < 0)
            {
                return head;
            }

            if (head == null)
            {
                throw new ArgumentNullException();
            }

            if (head.next == null && n == 1)
            {
                // This is the only element in the array and the request is to remove it.
                return null;
            }

            ListNode current = head;
            for (int i = 0; i < n; i++)
            {
                current = current.next;
                if (current == null)
                {
                    return i == n - 1 ? head.next : head;
                }
            }

            // The current index have been moved `n` steps. The nFromLast index should now be positioned at the `head`.
            ListNode nFromLastPrev = head;

            // This algorithm doesn't include loop detection. So if a closed loop will be passed in, this will run forever.
            do
            {
                current = current.next;
                if (current == null)
                {
                    nFromLastPrev.next = nFromLastPrev.next?.next;
                    return head;
                }

                nFromLastPrev = nFromLastPrev.next;
            } while (true);
        }
    }
}
