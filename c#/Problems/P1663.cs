using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/smallest-string-with-a-given-numeric-value/
  ///    Submission: https://leetcode.com/submissions/detail/422929286/
  /// </summary>
  internal class P1663
  {
    public class Solution
    {
      public string GetSmallestString(int n, int k)
      {
        var ans = new List<int>();

        while (n > 0)
        {
          var max = Math.Min(k - (n - 1), 26);
          ans.Add(max);

          k -= max;
          n--;
        }

        ans.Reverse();

        return new string(ans.Select(i => (char)(97 - 1 + i)).ToArray());
      }
    }
  }
}
