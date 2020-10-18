using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/construct-target-array-with-multiple-sums/
  ///    Submission: https://leetcode.com/submissions/detail/303790486/
  /// </summary>
  internal class P1354
  {
    public class Solution
    {
      public bool IsPossible(int[] target)
      {
        long sum = target.Sum(x => (long)x);

        while (true)
        {
          var max = int.MinValue;
          var maxIndex = 0;

          for (int i = 0; i < target.Length; i++)
          {
            if (target[i] > max)
            {
              max = target[i];
              maxIndex = i;
            }
          }

          if (max == 1)
            return true;

          var restsum = sum - max;
          var prevval = max - restsum;

          if (prevval < 1)
            return false;

          target[maxIndex] = (int)prevval;
          sum = restsum + prevval;
        }

        return true;
      }
    }
  }
}
