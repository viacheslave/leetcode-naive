using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/determine-if-string-halves-are-alike/
  ///    Submission: https://leetcode.com/submissions/detail/435229190/
  /// </summary>
  internal class P1704
  {
    public class Solution
    {
      public bool HalvesAreAlike(string s)
      {
        var set = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        var indexes = new List<int>();

        for (var i = 0; i < s.Length; i++)
          if (set.Contains(s[i]))
            indexes.Add(i);

        return indexes.Count(i => i < s.Length / 2) == indexes.Count(i => i >= s.Length / 2);
      }
    }
  }
}
