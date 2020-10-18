using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-number-of-teams/
  ///    Submission: https://leetcode.com/submissions/detail/321322737/
  /// </summary>
  internal class P1395
  {
    public class Solution
    {
      public int NumTeams(int[] rating)
      {
        return Find(rating) + Find(rating.Reverse().ToArray());
      }

      private int Find(int[] arr)
      {
        var ans = 0;

        for (int i = 0; i < arr.Length - 2; i++)
        {
          for (int j = i + 1; j < arr.Length - 1; j++)
          {
            if (arr[j] < arr[i])
              continue;

            for (int k = j + 1; k < arr.Length; k++)
            {
              if (arr[k] < arr[j])
                continue;

              ans++;
            }
          }
        }

        return ans;
      }
    }
  }
}
