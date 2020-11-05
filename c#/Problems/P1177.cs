using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/can-make-palindrome-from-substring/
  ///    Submission: https://leetcode.com/submissions/detail/417091296/
  /// </summary>
  internal class P1177
  {
    public class Solution
    {
      public IList<bool> CanMakePaliQueries(string s, int[][] queries)
      {
        var ans = new List<bool>(queries.Length);

        var freq = new Dictionary<char, int>[s.Length + 1];
        freq[0] = s.Distinct().ToDictionary(x => x, x => 0);

        for (var i = 1; i < s.Length + 1; i++)
        {
          freq[i] = new Dictionary<char, int>(freq[i - 1]);
          freq[i][s[i - 1]]++;
        }

        foreach (var query in queries)
          ans.Add(CanMake(query[0], query[1], query[2], freq));

        return ans;
      }

      private bool CanMake(int from, int to, int exch, Dictionary<char, int>[] freq)
      {
        var f = new Dictionary<char, int>();

        foreach (var entry in freq[to])
          f[entry.Key] = freq[to + 1][entry.Key] - freq[from][entry.Key];

        var odd = f.Count(x => x.Value % 2 == 1);

        return odd / 2 <= exch;
      }
    }
  }
}
