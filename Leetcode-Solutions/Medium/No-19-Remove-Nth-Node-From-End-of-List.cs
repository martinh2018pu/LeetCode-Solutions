namespace Leetcode_Solutions.Medium
{
    using System;

    class No_19_Remove_Nth_Node_From_End_of_List
    {
        /// <summary>
        /// Definition for singly-linked list.
        /// </summary>
        private class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static void PrintResultOfRemoveNthFromEnd()
        {
            var head = TestCaseOddCount();
            var n = 1;
            var head2 = TestCaseEvenCount();
            var n2 = 8;

            // TODO: Make 4 more test cases apart from existing 2 

            // Four example inputs:

            //[1,2,3,4,5]
            //2

            //[1]
            //1

            //[1, 2]
            //1

            //[1, 2]
            //2


            // Expexted outputs:

            //[1,2,3,5]

            //[]

            //[1]

            //[2]

            var resultHead = RemoveNthFromEnd(head2, n2); // Pass head/n or head2/n2 as pre-made Test Cases

            Console.WriteLine();
            Console.Write("[" + resultHead.val);

            while (resultHead.next != null)
            {
                resultHead = resultHead.next;
                Console.Write(", " + resultHead.val);
            }

            Console.Write("]");
        }
        
        static int NodesCount { get; set; }

        static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            NodesCount = -1; // NodesCount is -1 instead of 0 because of the code: new ListNode(0, head) which is the nonCountable ListNode

            if (head.next == null)
                return null;

            return DownToBottomAndUp(new ListNode(0, head), n).next;    // var nonCountable = new ListNode(0, head); is the param code: new ListNode(0, head)
        }

        /// <summary>
        /// Removes Nth Node From End of List and returns new head which is the non-Countable fake start head we put at the invocation: DownToBottomAndUp(new ListNode(0, head), n)
        /// That is why we return the .next , because we do not need that non-Countable fake start head
        /// As a result, please use this correct invocation: DownToBottomAndUp(new ListNode(0, head), n).next
        /// </summary>
        /// <param name="head">Here you shoud pass nonCountable as a param code: new ListNode(0, head)</param>
        /// <param name="n">Nth Node From End of List</param>
        /// <param name="iterationNo">Iteration number puts number on each recursion iteration. For ex: recursion last invocation is 5 then it starts backwards after it has reached return keyword - 4 then 3 then 2 and so on</param>
        /// <returns>Look the summary tag</returns>
        static ListNode DownToBottomAndUp(ListNode head, int n, int iterationNo = 0) // iterationNo is 0 instead of 1 because of the code: new ListNode(0, head) which is the nonCountable ListNode
        {
            NodesCount = NodesCount + 1;

            if (head.next == null)
                return head;

            DownToBottomAndUp(head.next, n, iterationNo + 1);   // Recursion

            if (NodesCount - iterationNo == n)  // NodesCount - iterationNo is equal to the (Nth - 1) Node From End of List
            {
                head.next = head.next.next; // Removes Nth Node From End of List
            }

            return head;
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
