using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/swap-adjacent-in-lr-string/
  ///    Submission: https://leetcode.com/submissions/detail/246221400/
  /// </summary>
  internal class P0777
  {
    public class Solution
    {
      public bool CanTransform(string start, string end)
      {
        if (start.Length != end.Length)
          return false;

        var startPos = new List<(char ch, int pos)>();
        var endPos = new List<(char ch, int pos)>();

        for (int i = 0; i < start.Length; i++)
        {
          if (start[i] != 'X')
            startPos.Add((start[i], i));
        }

        for (int i = 0; i < end.Length; i++)
        {
          if (end[i] != 'X')
            endPos.Add((end[i], i));
        }

        if (startPos.Count != endPos.Count)
          return false;

        var index = 0;
        while (index < startPos.Count)
        {
          var startItem = startPos[index];
          var endItem = endPos[index];

          if (startItem.ch != endItem.ch)
            return false;

          var ch = startItem.ch;

          if (ch == 'R' && endItem.pos < startItem.pos)
            return false;

          if (ch == 'L' && endItem.pos > startItem.pos)
            return false;

          index++;
        }

        return true;
      }
    }
  }
}
