using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/random-point-in-non-overlapping-rectangles/
  ///    Submission: https://leetcode.com/submissions/detail/244901247/
  /// </summary>
  internal class P0497
  {
    private readonly int[][] _rects;
    private readonly int _count;
    private readonly Random _random = new Random();

    public P0497(int[][] rects)
    {
      _rects = rects;

      var count = 0;
      foreach (var rect in rects)
        count += (rect[2] - rect[0] + 1) * (rect[3] - rect[1] + 1);

      _count = count;
    }

    public int[] Pick()
    {
      var rnd = _random.Next(_count);

      var area = 0;
      var rectIndex = 0;

      while (rnd >= area)
      {
        area +=
            (_rects[rectIndex][2] - _rects[rectIndex][0] + 1) *
            (_rects[rectIndex][3] - _rects[rectIndex][1] + 1);
        rectIndex++;
      }

      rectIndex--;

      area -=
              (_rects[rectIndex][2] - _rects[rectIndex][0] + 1) *
              (_rects[rectIndex][3] - _rects[rectIndex][1] + 1);


      var relativeIndex = rnd - area;

      var rows = _rects[rectIndex][3] - _rects[rectIndex][1] + 1;

      var xShift = relativeIndex / rows;
      var yShift = relativeIndex % rows;

      return new int[] { _rects[rectIndex][0] + xShift, _rects[rectIndex][1] + yShift   };
    }
  }
}
