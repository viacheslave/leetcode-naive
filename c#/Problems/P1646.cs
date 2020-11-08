using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/get-maximum-in-generated-array/
  ///    Submission: https://leetcode.com/submissions/detail/418087955/
  /// </summary>
  internal class P1646
  {
    public class Solution
    {
      public int GetMaximumGenerated(int n)
      {
        if (n == 0)
          return 0;

        if (n == 1)
          return 1;

        var arr = new int[n + 1];
        arr[0] = 0;
        arr[1] = 1;

        for (var i = 2; i < n + 1; i++)
        {
          if (i % 2 == 0)
            arr[i] = arr[i / 2];
          else
            arr[i] = arr[(i - 1) / 2] + arr[(i - 1) / 2 + 1];
        }

        return arr.Max();
      }
    }
  }
}
