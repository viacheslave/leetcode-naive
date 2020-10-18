using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/shuffle-string/
  ///    Submission: https://leetcode.com/submissions/detail/387686162/
  /// </summary>
  internal class P1528
  {
    public class Solution
    {
      public string RestoreString(string s, int[] indices)
      {
        var ans = new char[s.Length];

        for (var i = 0; i < s.Length; i++)
          ans[indices[i]] = s[i];

        return new string(ans);
      }
    }
  }
}
