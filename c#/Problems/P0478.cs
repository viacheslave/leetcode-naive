using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/generate-random-point-in-a-circle/
  ///    Submission: https://leetcode.com/submissions/detail/242832646/
  /// </summary>
  internal class P0478
  {
    private readonly Random _rnd = new Random((int)DateTime.Now.Ticks);

    private readonly double _r;
    private (double, double) _c;

    public P0478(double radius, double x_center, double y_center)
    {
      _r = radius;
      _c = (x_center, y_center);
    }

    public double[] RandPoint()
    {
      double rx = 1, ry = 1;
      while ((rx * rx) + (ry * ry) > 1)
      {
        rx = _rnd.NextDouble();
        ry = _rnd.NextDouble();
      }

      var coeffx = _rnd.Next(2) % 2 == 0 ? 1 : -1;
      var coeffy = _rnd.Next(2) % 2 == 0 ? 1 : -1;

      var p = ((rx * coeffx * _r) + _c.Item1, (ry * coeffy * _r) + _c.Item2);

      return new double[] { p.Item1, p.Item2   };
    }
  }
}
