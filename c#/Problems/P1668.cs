using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-repeating-substring/
  ///    Submission: https://leetcode.com/submissions/detail/427136564/
  /// </summary>
  internal class P1668
  {
    public class Solution
    {
      public int MaxRepeating(string sequence, string word)
      {
        var ans = 0;
        var count = 0;
        var pos = 0;

        while (true)
        {
          var index = sequence.IndexOf(word, pos);
          if (index == -1)
            break;

          if (index == pos)
          {
            count++;
          }
          else
          {
            ans = Math.Max(ans, count);
            count = 1;
          }

          pos += (index - pos) + word.Length;
        }

        ans = Math.Max(ans, count);
        return ans;
      }
    }
  }
}
