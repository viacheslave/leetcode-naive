using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{

  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-sub-arrays-with-odd-sum/
  ///    Submission: https://leetcode.com/submissions/detail/406253251/
  /// </summary>
  internal class P1524
  {
    public class Solution
    {
      public int NumOfSubarrays(int[] arr)
      {
        const int mod = (int)1e9 + 7;
        var length = arr.Length;

        var dp_odd = new int[length + 1];
        var dp_even = new int[length + 1];

        dp_odd[0] = 0;
        dp_even[0] = 0;

        for (var i = 0; i < length; ++i)
        {
          if (arr[i] % 2 == 0)
          {
            dp_even[i + 1] = dp_even[i] + 1;
            dp_odd[i + 1] = dp_odd[i];
          }
          else
          {
            dp_odd[i + 1] = dp_even[i] + 1;
            dp_even[i + 1] = dp_odd[i];
          }

          dp_even[i + 1] %= mod;
          dp_odd[i + 1] %= mod;
        }

        var ans = 0;
        for (int i = 0; i < length + 1; i++)
        {
          ans += dp_odd[i];
          ans %= mod;
        }

        return ans;
      }
    }
  }
}
