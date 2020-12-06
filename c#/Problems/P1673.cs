using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-the-most-competitive-subsequence/
  ///    Submission: https://leetcode.com/submissions/detail/427815957/
  /// </summary>
  internal class P1673
  {
    public class Solution
    {
      public int[] MostCompetitive(int[] nums, int k)
      {
        var stack = new Stack<int>();

        for (var index = 0; index < nums.Length; index++)
        {
          var el = nums[index];
          var available = nums.Length - index;

          if (stack.Count == 0 || (stack.Count < k && stack.Peek() < el))
          {
            stack.Push(el);
            continue;
          }

          while (stack.Count > 0 && stack.Peek() > el && stack.Count + available > k)
            stack.Pop();

          if (stack.Count < k)
            stack.Push(el);
        }

        var list = stack.ToList();
        list.Reverse();

        return list.ToArray();
      }
    }
  }
}
