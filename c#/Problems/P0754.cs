using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/submissions/detail/435540860/
  ///    Submission: https://leetcode.com/submissions/detail/435540860/
  /// </summary>
  internal class P0754
  {
    public class Solution
    {
      public int ReachNumber(int target)
      {
        target = Math.Abs(target);

        var steps = 0;
        var sum = 0;

        while (true)
        {
          if (sum == target)
            return steps;

          // accumulate sum until it's greater than a target
          if (sum < target)
          {
            steps++;
            sum += steps;
            continue;
          }

          var diff = sum - target;

          // if diff is even that we can reach a target by reverting one step:
          // it should be even: one move forward + the same move back
          if (diff % 2 == 0)
            return steps;

          // otherwise - accumulate until it's even
          steps++;
          sum += steps;
        }
      }
    }
  }
}
