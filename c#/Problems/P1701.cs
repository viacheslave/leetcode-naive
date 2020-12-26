using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/average-waiting-time/
  ///    Submission: https://leetcode.com/submissions/detail/434795066/
  /// </summary>
  internal class P1701
  {
    public class Solution
    {
      public double AverageWaitingTime(int[][] customers)
      {
        var waitTimes = new int[customers.Length];
        var finishes = 0;

        for (var i = 0; i < customers.Length; i++)
        {
          var customer = customers[i];
          var start = customer[0];
          var takes = customer[1];

          var expectedFinish = start + takes;
          var actualFinish = finishes <= start
            ? expectedFinish
            : finishes + takes;

          waitTimes[i] = takes + actualFinish - expectedFinish;

          finishes = actualFinish;
        }

        return waitTimes.Average();
      }
    }
  }
}
