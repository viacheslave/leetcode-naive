using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-score-from-removing-stones/
  ///    Submission: https://leetcode.com/submissions/detail/492257941/
  /// </summary>
  internal class P1753
  {
    public class Solution
    {
      public int MaximumScore(int a, int b, int c)
      {
        var arr = new int[] { a, b, c };
        var score = 0;

        while (true)
        {
          if (
            (arr[0] == 0 && arr[1] == 0) ||
            (arr[1] == 0 && arr[2] == 0) ||
            (arr[0] == 0 && arr[2] == 0))
            break;

          var ind = GetMaxInd(arr);
          arr[ind.Item1]--;
          arr[ind.Item2]--;
          score++;
        }

        return score;
      }

      public (int, int) GetMaxInd(int[] arr)
      {
        if (arr[0] <= arr[1] && arr[0] <= arr[2])
          return (1, 2);
        if (arr[1] <= arr[0] && arr[1] <= arr[2])
          return (0, 2);
        return (0, 1);
      }
    }
  }
}
