using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-good-triplets/
  ///    Submission: https://leetcode.com/submissions/detail/387678209/
  /// </summary>
  internal class P1534
  {
    public class Solution
    {
      public int CountGoodTriplets(int[] arr, int a, int b, int c)
      {
        var ans = 0;

        for (int i = 0; i < arr.Length - 2; i++)
        {
          for (int j = i + 1; j < arr.Length - 1; j++)
          {
            for (int k = j + 1; k < arr.Length; k++)
            {
              var sa = Math.Abs(arr[i] - arr[j]);
              var sb = Math.Abs(arr[j] - arr[k]);
              var sc = Math.Abs(arr[i] - arr[k]);

              if (sa <= a && sb <= b && sc <= c)
                ans++;
            }
          }
        }

        return ans;
      }
    }
  }
}
