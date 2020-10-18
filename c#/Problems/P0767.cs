using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/reorganize-string/
  ///    Submission: https://leetcode.com/submissions/detail/238308970/
  /// </summary>
  internal class P0767
  {
    public class Solution
    {
      public string ReorganizeString(string S)
      {
        var dict = S.Select(_ => _)
            .GroupBy(_ => _)
            .ToDictionary(_ => _.Key, _ => _.Count());

        var topChar = dict
            .OrderByDescending(_ => _.Value)
            .First();

        if (S.Length % 2 == 0 && topChar.Value > S.Length / 2)
          return "";

        if (S.Length % 2 == 1 && topChar.Value > S.Length / 2 + 1)
          return "";

        char ch = default(char);
        char[] arr = new char[S.Length];

        for (var i = 0; i < arr.Length; i++)
        {
          if (ch == default(char))
          {
            ch = dict.OrderByDescending(_ => _.Value).First().Key;
            dict[ch]--;
            arr[i] = ch;
            continue;
          }

          ch = dict.Where(_ => _.Key != ch).OrderByDescending(_ => _.Value).First().Key;
          dict[ch]--;
          arr[i] = ch;
        }

        return new string(arr);
      }
    }
  }
}
