using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-number-of-operations-to-reinitialize-a-permutation/
  ///    Submission: https://leetcode.com/submissions/detail/476427567/
  /// </summary>
  internal class P1806
  {
    public class Solution
    {
      public int ReinitializePermutation(int n)
      {
        var target = Enumerable.Range(0, n).ToArray();
        var arr = new int[target.Length];
        Array.Copy(target, arr, target.Length);

        var ans = 0;

        while (true)
        {
          // permute
          var next = new int[target.Length];
          for (var i = 0; i < arr.Length; ++i)
            next[i] = i % 2 == 0 ? arr[i / 2] : arr[n / 2 + (i - 1) / 2];

          arr = next;
          ans++;

          // check
          var istarget = true;
          for (var i = 0; i < arr.Length; ++i)
          {
            if (arr[i] != target[i])
            {
              istarget = false;
              break;
            }
          }

          if (istarget)
            return ans;
        }
      }
    }
  }
}
