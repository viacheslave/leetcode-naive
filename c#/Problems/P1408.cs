using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/string-matching-in-an-array/
  ///    Submission: https://leetcode.com/submissions/detail/324358094/
  /// </summary>
  internal class P1408
  {
    public class Solution
    {
      public IList<string> StringMatching(string[] words)
      {
        var ans = new List<string>();
        words = words.OrderBy(w => w.Length).ToArray();

        for (int i = 0; i < words.Length; i++)
        {
          for (int j = i + 1; j < words.Length; j++)
          {
            if (words[j].IndexOf(words[i]) != -1)
            {
              ans.Add(words[i]);
              break;
            }
          }
        }

        return ans.ToList();
      }
    }
  }
}
