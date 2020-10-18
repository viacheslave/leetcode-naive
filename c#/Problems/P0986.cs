using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/interval-list-intersections/
  ///    Submission: https://leetcode.com/submissions/detail/388469318/
  /// </summary>
  internal class P0986
  {
    public class Solution
    {
      public int[][] IntervalIntersection(int[][] A, int[][] B)
      {
        if (A.Length == 0 || B.Length == 0)
          return new int[0][];

        int a = 0, b = 0;
        var ans = new List<(int, int)>();

        while (true)
        {
          var cura = (A[a][0], A[a][1]);
          var curb = (B[b][0], B[b][1]);

          if (Intersects(cura, curb))
          {
            var intersection = GetIntersection(cura, curb);
            ans.Add(intersection);
          }

          if (a == A.Length - 1 && b == B.Length - 1)
            break;
          else if (a == A.Length - 1)
            b++;
          else if (b == B.Length - 1)
            a++;
          else
          {
            if (cura.Item2 <= curb.Item2)
              a++;
            else
              b++;
          }
        }

        return ans.Select(a => new int[] { a.Item1, a.Item2 }).ToArray();
      }

      private (int, int) GetIntersection((int, int) cura, (int, int) curb)
      {
        if (curb.Item1 <= cura.Item1 && cura.Item2 <= curb.Item2)
          return cura;

        if (cura.Item1 <= curb.Item1 && curb.Item2 <= cura.Item2)
          return curb;

        if (curb.Item1 <= cura.Item1)
          return (cura.Item1, curb.Item2);
        else
          return (curb.Item1, cura.Item2);
      }

      private bool Intersects((int, int) a, (int, int) b)
      {
        return a.Item1 <= b.Item2 && b.Item1 <= a.Item2;
      }
    }
  }
}
