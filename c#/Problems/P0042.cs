using System;
using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/trapping-rain-water/
  ///    Submission: https://leetcode.com/submissions/detail/432686498/
  /// </summary>
  internal class P0042
  {
    public class Solution
    {
      public int Trap(int[] height)
      {
        var ans = 0;
        var stack = new Stack<(int height, int pos)>();

        for (var i = 0; i < height.Length; i++)
        {
          var h = height[i];

          // if height descreases - just add it to stack
          if (stack.Count == 0 || h <= stack.Peek().height)
          {
            stack.Push((h, i));
            continue;
          }

          var current = stack.Pop();

          // search through stack for the most prev element with height
          // greater than next, and stop when it's greater than current 'h'
          while (stack.Count > 0 && stack.Peek().height >= current.height)
          {
            var hh = Math.Min(h, stack.Peek().height) - current.height;
            ans += hh * (i - stack.Peek().pos - 1);

            current = stack.Pop();

            if (current.height >= h)
            {
              stack.Push(current);
              break;
            }
          }

          stack.Push((h, i));
        }

        return ans;
      }
    }
  }
}
