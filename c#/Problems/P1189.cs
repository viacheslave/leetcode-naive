using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-number-of-balloons/
  ///    Submission: https://leetcode.com/submissions/detail/261039200/
  /// </summary>
  internal class P1189
  {
    public class Solution
    {
      public int MaxNumberOfBalloons(string text)
      {
        var map = text.GroupBy(c => c).ToDictionary(x => x.Key, x => x.Count());

        var count = 0;
        while (true)
        {
          var b = Fill(map, 'b', 1);
          var a = Fill(map, 'a', 1);
          var l = Fill(map, 'l', 2);
          var o = Fill(map, 'o', 2);
          var n = Fill(map, 'n', 1);

          if (b && a && l && o && n)
            count++;
          else break;
        }

        return count;
      }

      private bool Fill(Dictionary<char, int> map, char ch, int count)
      {
        if (map.ContainsKey(ch) && map[ch] >= count)
        {
          map[ch] -= count;
          return true;
        }

        return false;
      }
    }
  }
}
