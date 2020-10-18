using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/next-greater-element-iii/
  ///    Submission: https://leetcode.com/submissions/detail/238076017/
  /// </summary>
  internal class P0556
  {
    public class Solution
    {
      public int NextGreaterElement(int n)
      {
        var ch = n.ToString().Select(_ => int.Parse(_.ToString())).ToList();
        if (ch.Count == 1)
          return -1;

        for (var i = ch.Count - 2; i >= 0; i--)
        {
          var maxIndex = -1;
          var minValue = int.MaxValue;

          for (var j = i + 1; j < ch.Count; j++)
          {
            if (ch[j] > ch[i])
            {
              if (ch[j] < minValue)
              {
                minValue = ch[j];
                maxIndex = j;
              }
            }
          }

          if (maxIndex == -1)
            continue;

          // swap
          var tmp = ch[i];
          ch[i] = ch[maxIndex];
          ch[maxIndex] = tmp;

          // order last
          var f = ch.Take(i + 1).ToList();
          var l = ch.Skip(i + 1).OrderBy(_ => _);
          ch = f.Concat(l).ToList();

          try
          {
            return int.Parse(string.Join("", ch.Select(_ => _.ToString())));
          }
          catch (OverflowException)
          {
            return -1;
          }

        }

        return -1;
      }
    }
  }
}
