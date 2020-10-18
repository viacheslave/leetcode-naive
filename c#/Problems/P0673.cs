using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-longest-increasing-subsequence/
  ///    Submission: https://leetcode.com/submissions/detail/249650071/
  /// </summary>
  internal class P0673
  {
    public class Solution
    {
      public int FindNumberOfLIS(int[] nums)
      {
        if (nums.Length == 0)
          return 0;

        var lis = new Dictionary<int, (int length, int count)>();

        for (int i = 0; i < nums.Length; i++)
        {
          var ithlength = 0;
          var ithcount = 0;

          for (int j = 0; j < i; j++)
          {
            if (nums[j] < nums[i])
            {
              if (lis[j].length + 1 == ithlength)
              {
                ithcount += lis[j].count;
              }

              if (lis[j].length + 1 > ithlength)
              {
                ithlength = lis[j].length + 1;
                ithcount = lis[j].count;
              }
            }
          }

          if (ithlength == 0)
          {
            ithlength = 1;
            ithcount = 1;
          }

          lis[i] = (ithlength, ithcount);
        }

        var maxLength = lis.Values.Max(_ => _.length);
        return lis.Where(_ => _.Value.length == maxLength).Sum(_ => _.Value.count);
      }
    }
  }
}
