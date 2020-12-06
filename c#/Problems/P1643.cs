using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/kth-smallest-instructions/
  ///    Submission: https://leetcode.com/submissions/detail/427762202/
  /// </summary>
  internal class P1643
  {
    public class Solution
    {
      public string KthSmallestPath(int[] destination, int k)
      {
        var maxX = destination[0];
        var maxY = destination[1];

        var point = (x: 0, y: 0);
        var target = (x: destination[0], y: destination[1]);
        var range = (start: 1, end: Cr(maxX + maxY, maxX));

        var sb = new StringBuilder();

        while (point != target)
        {
          if (point.x == target.x)
          {
            point = (point.x, point.y + 1);
            sb.Append("H");
            continue;
          }

          if (point.y == target.y)
          {
            point = (point.x + 1, point.y);
            sb.Append("V");
            continue;
          }

          var lpoint = (x: point.x, y: point.y + 1);
          var dpoint = (x: point.x + 1, y: point.y);

          var lCr = Cr(maxY - lpoint.y + maxX - lpoint.x, maxX - lpoint.x);
          var dCr = Cr(maxY - dpoint.y + maxX - dpoint.x, maxX - dpoint.x);

          var hRange = (start: range.start, end: range.start + lCr - 1);
          var vRange = (start: range.end - dCr + 1, end: range.end);

          if (hRange.start <= k && k <= hRange.end)
          {
            range = hRange;
            point = (point.x, point.y + 1);
            sb.Append("H");
          }
          else
          {
            range = vRange;
            point = (point.x + 1, point.y);
            sb.Append("V");
          }
        }

        return sb.ToString();
      }

      public int Cr(int n, int r)
        => (int)(Fact(n) / (Fact(r) * Fact(n - r)));

      public BigInteger Fact(int n)
        => Enumerable.Range(1, n).Aggregate(BigInteger.One, (p, item) => BigInteger.Multiply(p, new BigInteger(item)));
    }
  }
}
