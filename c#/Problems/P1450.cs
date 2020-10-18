using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-students-doing-homework-at-a-given-time/
  ///    Submission: https://leetcode.com/submissions/detail/387698346/
  /// </summary>
  internal class P1450
  {
    public class Solution
    {
      public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
      {
        var ans = 0;

        for (var i = 0; i < startTime.Length; i++)
        {
          if (startTime[i] <= queryTime && queryTime <= endTime[i])
            ans++;
        }

        return ans;
      }
    }
  }
}
