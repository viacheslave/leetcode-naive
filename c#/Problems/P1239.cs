using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/
  ///    Submission: https://leetcode.com/submissions/detail/421337427/
  /// </summary>
  internal class P1239
  {
    public class Solution
    {
      public int MaxLength(IList<string> arr)
      {
        arr = arr
          .Where(s => s.GroupBy(c => c).Max(v => v.Count()) == 1)
          .ToList();

        if (arr.Count == 0)
          return 0;

        var dp = new Dictionary<long, int>();
        dp.Add(Mask(arr[0]), arr[0].Length);

        for (var i = 1; i < arr.Count; i++)
        {
          var word = arr[i];
          var mask = Mask(word);
          var keys = dp.Keys.ToArray();

          dp[mask] = dp.ContainsKey(mask)
            ? Math.Max(dp[mask], word.Length)
            : word.Length;

          foreach (var key in keys)
          {
            if ((key & mask) != 0)
              continue;

            var updmask = key | mask;

            dp[updmask] = dp.ContainsKey(updmask)
              ? Math.Max(dp[updmask], dp[key] + word.Length)
              : dp[key] + word.Length;
          }
        }

        return dp.Max(x => x.Value);
      }

      private long Mask(string str)
      {
        long m = 0L;

        foreach (var ch in str)
        {
          var pos = ch - 97;
          m += (long)Math.Pow(2, pos);
        }

        return m;
      }
    }
  }
}
