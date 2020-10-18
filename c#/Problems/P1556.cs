using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/thousand-separator/
  ///    Submission: https://leetcode.com/submissions/detail/387704128/
  /// </summary>
  internal class P1556
  {
    public class Solution
    {
      public string ThousandSeparator(int n)
      {
        var original = n.ToString();

        var ans = new List<char>();

        for (var i = 0; i < original.Length; i++)
        {
          if (i > 0 && i % 3 == 0)
            ans.Add('.');

          ans.Add(original[original.Length - 1 - i]);
        }

        ans.Reverse();
        return new string(ans.ToArray());
      }
    }
  }
}
