using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-units-on-a-truck/
  ///    Submission: https://leetcode.com/submissions/detail/438039365/
  /// </summary>
  internal class P1710
  {
    public class Solution
    {
      public int MaximumUnits(int[][] boxTypes, int truckSize)
      {
        var boxes = boxTypes.Select(x => (count: x[0], units: x[1]))
          .OrderByDescending(x => x.units)
          .ToList();

        var ans = 0;

        for (var i = 0; i < boxes.Count; i++)
        {
          var box = boxes[i];
          var take = truckSize >= box.count ? box.count : truckSize;

          ans += take * box.units;
          truckSize -= take;

          if (truckSize == 0)
            break;
        }

        return ans;
      }
    }
  }
}
