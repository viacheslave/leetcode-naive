using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-the-number-of-consistent-strings/
  ///    Submission: https://leetcode.com/contest/biweekly-contest-41/submissions/detail/429863088/
  /// </summary>
  internal class P1684
  {
    public class Solution
    {
      public int CountConsistentStrings(string allowed, string[] words)
      {
        var mapAllowed = allowed.Distinct().ToHashSet();

        var ans = 0;

        foreach (var w in words)
        {
          var map = w.Distinct().ToHashSet();
          map.ExceptWith(mapAllowed);

          if (map.Count == 0)
            ans++;
        }

        return ans;
      }
    }
  }
}
