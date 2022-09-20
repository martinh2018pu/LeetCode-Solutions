namespace Leetcode_Solutions.Easy
{
    using System;

    /// <summary>
    /// Definition for singly-linked list
    /// </summary>
    class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class No_234_Palindrome_Linked_List
    {
        public static void PrintIsPalindrome()
        {
            var head = TestCaseOddCount();
            var head2 = TestCaseEvenCount();

            bool isPalindrome = IsPalindrome(head); // Pass head or head2 as pre-made Test Cases

            Console.WriteLine();
            Console.WriteLine(isPalindrome);
        }

        /// <summary>
        /// Checks if singly-linked list is palindrome
        /// </summary>
        /// <param name="head">Starting head</param>
        /// <returns>True if the linked list is palindrome, false otherwise</returns>
        static bool IsPalindrome(ListNode head)
        {
            Console.WriteLine("Linked list before reversing:");

            for (var x = head; x != null; x = x.next)
            {
                Console.WriteLine(x.val);
            }

            Console.WriteLine();
            Console.WriteLine("Result from reversing from middle of linked list to end:");

            var middleHead = FindMiddle(head);

            //var newHeadOfReversedFromMiddle = Reverse(middle);
            middleHead = Reverse(middleHead);   // reuse the variable instead of creating the new one above

            for (var y = middleHead; y != null; y = y.next)
            {
                Console.WriteLine(y.val);
            }

            // Checks if first half of the Linked List is same as 
            // the reversed from the middle (the second half reversed) of the Linked List.

            while (middleHead != null)
            {
                if (head.val != middleHead.val)
                    return false;   // If one is not the same => return false

                head = head.next;
                middleHead = middleHead.next;
            }

            return true;    // If all are the same => return true
        }

        /// <summary>
        /// Finds middle of singly-linked list
        /// </summary>
        /// <param name="head">Starting head</param>
        /// <returns>The middle node</returns>
        /// <remarks>
        /// If linked list nodes count is even, then it will return the node which is in the middle position equal to ((nodes count / 2) + 1) 
        /// This remarks are needed because when nodes count is even (for example) = 6 then both 3rd and 4th node are in the middle
        /// </remarks>
        /// <example>Nodes count is even (for example) = 6 ,then it will return (6 / 2) + 1 = 4 which is the 4th node</example>
        static ListNode FindMiddle(ListNode head)
        {
            if (head == null)
                return head;

            ListNode fast = head;   // Will go beyond the end
            ListNode slow = head;   // Will go to the middle when fast is beyond the end

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;  // +2 each iteration
                slow = slow.next;       // +1 each iteration
            }

            return slow;    // The middle node
        }

        /// <summary>
        /// Reverses singly-linked list
        /// </summary>
        /// <param name="head">Starting head</param>
        /// <returns>The new starting head of the reversed linked list</returns>
        static ListNode Reverse(ListNode head)
        {
            // (head == null) Checks if there are no elements and the passed head is null
            // (head.next == null) Checks if the recursion went to the last element (which will be the new starting head of the reversed linked list
            if (head == null || head.next == null)
                return head;

            ListNode temp = Reverse(head.next); // Recursion

            // Example: head=2 head.next=1 head.next.next=null -- and temp=1
            head.next.next = head;  // Moves head after head.next -- Result: head=2 head.next=1 head.next.next=2 -- and temp=1
            head.next = null;       // Removes head.next -- Result: head=2 head.next=null head.next.next=(null.next is Exception) -- and temp=1
                                    // -- but now we have temp=1 temp.next=2 temp.next.next = null 
                                    // -- this is the result of recursion and at the end we will have 1-2-3-4 which is reversed of 4-3-2-1

            return temp;    //The new starting head of the reversed linked list
        }

        static ListNode TestCaseOddCount()
        {
            var nod9 = new ListNode(1, null);
            var nod8 = new ListNode(2, nod9);
            var nod7 = new ListNode(3, nod8);
            var nod6 = new ListNode(4, nod7);
            var nod5 = new ListNode(5, nod6);
            var nod4 = new ListNode(4, nod5);
            var nod3 = new ListNode(3, nod4);
            var nod2 = new ListNode(2, nod3);

            var head = new ListNode(1, nod2);

            return head;
        }

        static ListNode TestCaseEvenCount()
        {
            var nod8 = new ListNode(1, null);
            var nod7 = new ListNode(2, nod8);
            var nod6 = new ListNode(3, nod7);
            var nod5 = new ListNode(4, nod6);
            var nod4 = new ListNode(4, nod5);
            var nod3 = new ListNode(3, nod4);
            var nod2 = new ListNode(2, nod3);

            var head = new ListNode(1, nod2);

            return head;
        }
    }
}
