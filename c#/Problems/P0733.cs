using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/flood-fill/
  ///    Submission: https://leetcode.com/submissions/detail/234073155/
  /// </summary>
  internal class P0733
  {
    public class Solution
    {
      public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
      {
        var hs = new HashSet<(int, int)>();

        Fill(image, sr, sc, newColor, image[sr][sc], hs);
        return image;
      }

      private void Fill(int[][] image, int sr, int sc, int newColor, int origColor, HashSet<(int, int)> hs)
      {
        var row = sr;
        var col = sc;

        row = sr;
        col = sc - 1;

        image[sr][sc] = newColor;
        hs.Add((sr, sc));

        if (InRange(image, row, col) && image[row][col] == origColor && !hs.Contains((row, col)))
          Fill(image, row, col, newColor, origColor, hs);

        row = sr;
        col = sc + 1;

        if (InRange(image, row, col) && image[row][col] == origColor && !hs.Contains((row, col)))
          Fill(image, row, col, newColor, origColor, hs);

        row = sr - 1;
        col = sc;

        if (InRange(image, row, col) && image[row][col] == origColor && !hs.Contains((row, col)))
          Fill(image, row, col, newColor, origColor, hs);

        row = sr + 1;
        col = sc;

        if (InRange(image, row, col) && image[row][col] == origColor && !hs.Contains((row, col)))
          Fill(image, row, col, newColor, origColor, hs);
      }

      private bool InRange(int[][] image, int sr, int sc)
      {
        if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length)
          return false;

        return true;
      }
    }
  }
}
