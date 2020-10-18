using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/xor-queries-of-a-subarray/
  ///    Submission: https://leetcode.com/submissions/detail/291434616/
  /// </summary>
  internal class P1310
  {
    public class Solution
    {
      public int[] XorQueries(int[] arr, int[][] queries)
      {
        var pref = new int[arr.Length];
        var suff = new int[arr.Length];

        for (int i = 0; i < arr.Length; i++)
        {
          if (i == 0)
          {
            pref[0] = arr[i];
            suff[arr.Length - 1] = arr[arr.Length - 1];
            continue;
          }

          pref[i] = pref[i - 1] ^ arr[i];
          suff[arr.Length - 1 - i] = suff[arr.Length - i] ^ arr[arr.Length - i - 1];
        }

        var ans = new List<int>();

        foreach (var query in queries)
        {
          var value = pref[arr.Length - 1];
          if (query[0] > 0)
            value ^= pref[query[0] - 1];

          if (query[1] < arr.Length - 1)
            value ^= suff[query[1] + 1];

          ans.Add(value);
        }

        return ans.ToArray();
      }
    }
  }
}
