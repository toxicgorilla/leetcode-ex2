namespace LeetCode.Ex2
{
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var currentNode1 = l1;
            var currentNode2 = l2;

            var currentL1Val = currentNode1.val;
            var currentL2Val = currentNode2.val;

            var currentSum = currentL1Val + currentL2Val;
            var currentCarryOver = currentSum > 9;
            var currentAnswer = currentCarryOver ? currentSum % 10 : currentSum;

            var headNode = new ListNode(currentAnswer);
            var currentNode = headNode;
            while (currentNode1?.next != null || currentNode2?.next != null || currentCarryOver)
            {
                currentNode1 = currentNode1?.next;
                currentNode2 = currentNode2?.next;

                currentL1Val = currentNode1?.val ?? 0;
                currentL2Val = currentNode2?.val ?? 0;

                currentSum = currentL1Val + currentL2Val;
                if (currentCarryOver)
                {
                    currentSum++;
                }

                currentCarryOver = currentSum > 9;
                currentAnswer = currentCarryOver ? currentSum % 10 : currentSum;

                var newNode = new ListNode(currentAnswer);
                currentNode.next = newNode;
                currentNode = newNode;
            }

            return headNode;
        }
    }
}
