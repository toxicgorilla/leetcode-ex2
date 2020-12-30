using System;
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
        public void ShouldReturnCorrectResultWhenSolutionExists(int[] input1, int[] input2, int[] expectedOutput)
        {
            // Arrange
            var list1 = GetLinkedListFromArray(input1);
            var list2 = GetLinkedListFromArray(input2);
            var expectedOutputList = GetLinkedListFromArray(expectedOutput);

            // Act
            var solution = new Solution();
            var actualOutputList = solution.AddTwoNumbers(list1, list2);

            //Assert
            actualOutputList.ShouldEqual(expectedOutputList);
        }

        private ListNode GetLinkedListFromArray(int[] input)
        {
            if (input == null || input.Length < 1)
            {
                throw new Exception("Input arrays must be non-empty");
            }

            var list = new ListNode(input[0], null);
            var current = list;
            for (var i = 1; i < input.Length; i++)
            {
                current.next = new ListNode(input[i], null);
            }

            return current;
        }
    }
}
