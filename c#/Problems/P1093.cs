using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/statistics-from-a-large-sample/
  ///    Submission: https://leetcode.com/submissions/detail/242806863/
  /// </summary>
  internal class P1093
  {
    public class Solution
    {
      public double[] SampleStats(int[] count)
      {
        var list = count.ToList();

        var min = list.IndexOf(list.FirstOrDefault(_ => _ > 0));
        var max = list.LastIndexOf(count.LastOrDefault(_ => _ > 0));

        var sampleCount = list.Sum();
        var sampleSum = count.Select((_, i) => ((long)_ * i)).Sum();

        var mean = sampleSum * 1.0 / sampleCount;


        var ind = (sampleCount % 2 == 0)
            ? (sampleCount / 2 - 1, sampleCount / 2)
            : ((sampleCount - 1) / 2, (sampleCount - 1) / 2);

        var v1 = -1;
        var v2 = -1;

        var index = 0;
        var total = 0;
        while (v1 == -1 || v2 == -1)
        {
          var c = list[index];
          total += c;

          if (v1 == -1 && total - 1 >= ind.Item1)
            v1 = index;

          if (v2 == -1 && total - 1 >= ind.Item2)
            v2 = index;

          index++;
        }

        var median = 1.0 * (v1 + v2) / 2;

        var mode = count.ToList().IndexOf(count.Max());

        return new double[] { min, max, mean, median, mode };
      }
    }
  }
}
