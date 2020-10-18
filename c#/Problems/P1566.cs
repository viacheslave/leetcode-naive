using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/detect-pattern-of-length-m-repeated-k-or-more-times/
  ///    Submission: https://leetcode.com/submissions/detail/390029009/
  /// </summary>
  internal class P1566
  {
    public class Solution
    {
      public bool ContainsPattern(int[] arr, int m, int k)
      {
        for (var startIndex = 0; startIndex <= arr.Length - m * k; startIndex++)
        {
          var contains = true;

          for (var pos = 0; pos < m; pos++)
          {
            contains &= Repeats(arr, startIndex + pos, m, k);
          }

          if (contains)
            return true;
        }

        return false;
      }

      private bool Repeats(int[] arr, int pos, int m, int k)
      {
        var values = new int[k];

        for (var i = 0; i < k; i++)
        {
          values[i] = arr[pos + m * i];
        }

        return values.Distinct().Count() == 1;
      }
    }
  }
}
