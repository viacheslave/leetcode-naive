using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/goat-latin/
  ///    Submission: https://leetcode.com/submissions/detail/231520053/
  /// </summary>
  internal class P0824
  {
    public class Solution
    {
      public string ToGoatLatin(string S)
      {
        var words = S.Split(new char[] { ' ' });

        for (var i = 0; i < words.Length; i++)
        {
          var f = Char.ToLower(words[i][0]);

          if (
             f == 'a' ||
             f == 'e' ||
             f == 'i' ||
             f == 'o' ||
             f == 'u')
            words[i] = words[i] + "ma";
          else
          {
            words[i] = (words[i].Length == 1)
                ? words[i] + "ma"
                : words[i].Substring(1) + words[i][0] + "ma";
          }

          words[i] = words[i] + new string('a', i + 1);
        }

        return string.Join(' ', words);
      }
    }
  }
}
