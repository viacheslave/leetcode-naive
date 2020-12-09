using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/can-convert-string-in-k-moves/
  ///    Submission: https://leetcode.com/submissions/detail/428900001/
  /// </summary>
  internal class P1540
  {
    public class Solution
    {
      public bool CanConvertString(string s, string t, int k)
      {
        if (s.Length != t.Length)
          return false;

        var diffs = Enumerable.Range(0, s.Length)
          .Select(i => (t[i] + 26 - s[i]) % 26)
          .OrderByDescending(x => x)
          .Where(x => x != 0)
          .ToList();

        // for each possible shift stored number of available actions
        var allowed = new int[26];
        for (var i = 1; i < 26; i++)
          if (k >= i)
            allowed[i] = 1 + ((k - i) / 26);

        // for each shift reduce from allowed
        foreach (var diff in diffs)
        {
          var value = diff;
          if (allowed[value] == 0)
            return false;

          allowed[value]--;
        }

        return true;
      }
    }
  }
}
