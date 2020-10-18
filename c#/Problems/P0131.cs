using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/palindrome-partitioning/
  ///    Submission: https://leetcode.com/submissions/detail/400631484/
  /// </summary>
  internal class P0131
  {
    public class Solution
    {
      public IList<IList<string>> Partition(string s)
      {
        var ans = new List<IList<string>>();
        var current = new List<string>();

        Partition(0, s, current, ans);

        return ans;
      }

      private void Partition(int start, string s, IList<string> current, List<IList<string>> ans)
      {
        if (start == s.Length)
        {
          ans.Add(new List<string>(current));
          return;
        }

        for (var end = start; end < s.Length; end++)
        {
          if (Palindrome(s, start, end))
          {
            current.Add(s.Substring(start, end - start + 1));

            Partition(end + 1, s, current, ans);

            current.RemoveAt(current.Count - 1);
          }
        }
      }

      private bool Palindrome(string s, int start, int end)
      {
        for (var i = 0; i < (end - start + 1) / 2; i++)
          if (s[start + i] != s[end - i])
            return false;

        return true;
      }
    }
  }
}
