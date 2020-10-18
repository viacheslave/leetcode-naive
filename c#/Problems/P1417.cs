using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/reformat-the-string/
  ///    Submission: https://leetcode.com/submissions/detail/327634816/
  /// </summary>
  internal class P1417
  {
    public class Solution
    {
      public string Reformat(string s)
      {
        var digits = s.Where(char.IsDigit).ToList();
        var letters = s.Where(d => !char.IsDigit(d)).ToList();

        if (Math.Abs(digits.Count - letters.Count) > 1)
          return string.Empty;

        List<char> s1;
        List<char> s2;

        if (digits.Count >= letters.Count)
        {
          s1 = digits;
          s2 = letters;
        }
        else
        {
          s2 = digits;
          s1 = letters;
        }

        var ans = new StringBuilder();
        for (var i = 0; i < s1.Count; i++)
        {
          ans.Append(s1[i]);
          if (i < s2.Count)
            ans.Append(s2[i]);
        }

        return ans.ToString();
      }
    }
  }
}
