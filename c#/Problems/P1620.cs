using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
	///		Problem: https://leetcode.com/problems/coordinate-with-maximum-network-quality/
	///		Submission: https://leetcode.com/submissions/detail/409898714/
	/// </summary>
	internal class P1620
  {
    public int[] BestCoordinate(int[][] towers, int radius)
    {
      var best = (x: -1, y: -1, q: -1d);

      for (int x = 0; x < 51; x++)
      {
        for (int y = 0; y < 51; y++)
        {
          var q = 0d;
          for (var t = 0; t < towers.Length; t++)
          {
            q += GetQuality((x, y), towers[t], radius);
          }

          if (best.q < q)
            best = (x, y, q);
          else if (best.q == q)
            if (x < best.x || (x == best.x && y < best.y))
              best = (x, y, q);
        }
      }

      return new int[] { best.x, best.y };
    }

    private double GetQuality((int x, int y) p, int[] tower, int radius)
    {
      var distance = Math.Sqrt(Math.Pow(tower[0] - p.x, 2) + Math.Pow(tower[1] - p.y, 2));
      if (distance > radius)
        return 0;

      return Math.Floor(tower[2] / (1 + distance));
    }
  }
}
