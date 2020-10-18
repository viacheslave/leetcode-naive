using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/letter-tile-possibilities/
  ///    Submission: https://leetcode.com/submissions/detail/238859664/
  /// </summary>
  internal class P1079
  {
    public class Solution
    {
      public int NumTilePossibilities(string tiles)
      {
        var fill = new bool[tiles.Length];
        var res = new HashSet<string>();
        var sb = new StringBuilder();

        Count(tiles, fill, res, sb);

        return res.Count;
      }

      private void Count(string tiles, bool[] fill, HashSet<string> res, StringBuilder sb)
      {
        for (var i = 0; i < fill.Length; i++)
        {
          if (fill[i])
            continue;

          fill[i] = true;

          sb.Append(tiles[i]);

          res.Add(sb.ToString());

          Count(tiles, fill, res, sb);

          sb.Remove(sb.Length - 1, 1);

          fill[i] = false;
        }
      }
    }
  }
}
