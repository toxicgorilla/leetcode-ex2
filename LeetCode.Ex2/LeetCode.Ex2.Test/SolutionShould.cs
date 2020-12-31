using System;
using System.Collections.Generic;
using Xunit;
using Should;

namespace LeetCode.Ex2.Test
{
    public class SolutionShould
    {
        [Theory]
        [InlineData(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
        [InlineData(new[] { 0 }, new[] { 0 }, new[] { 0 })]
        [InlineData(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
        [InlineData(new[] { 9 }, new[] { 1, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 })]
        [InlineData(new[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, new[] { 5, 6, 4 }, new[] { 6, 6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 })]
        public void ShouldReturnCorrectResultWhenSolutionExists(int[] input1, int[] input2, int[] expectedOutputArray)
        {
            // Arrange
            var list1 = GetLinkedListFromArray(input1);
            var list2 = GetLinkedListFromArray(input2);

            // Act
            var solution = new Solution();
            var actualOutputList = solution.AddTwoNumbers(list1, list2);
            var actualOutputArray = GetArrayFromLinkedList(actualOutputList);

            // Assert
            actualOutputArray.ShouldEqual(expectedOutputArray);
        }

        private ListNode GetLinkedListFromArray(int[] input)
        {
            if (input == null || input.Length < 1)
            {
                throw new Exception("Input arrays must be non-empty");
            }

            var start = new ListNode(input[0]);
            var current = start;
            for (var i = 1; i < input.Length; i++)
            {
                var newNode = new ListNode(input[i]);
                current.next = newNode;
                current = newNode;
            }

            return start;
        }

        private int[] GetArrayFromLinkedList(ListNode listNode)
        {
            var list = new List<int>();

            var current = listNode;
            while (current != null)
            {
                list.Add(current.val);
                current = current.next;
            }

            return list.ToArray();
        }
    }
}
