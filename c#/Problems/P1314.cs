using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/matrix-block-sum/
	///		Submission: https://leetcode.com/submissions/detail/293259651/
	/// </summary>
	internal class P1314
	{
    public int[][] MatrixBlockSum(int[][] mat, int K)
    {
      var rows = mat.Length;
      var cols = mat[0].Length;

      var dp = new List<List<int>>();

      for (var row = 0; row < rows; row++)
      {
        var list = new List<int>();

        for (var col = 0; col < cols; col++)
        {
          if (col == 0)
          {
            var sum = 0;
            for (var i = col - K; i <= col + K; i++)
            {
              if (i >= 0 && i < cols)
                sum += mat[row][i];
            }

            list.Add(sum);
            continue;
          }

          var value = list[col - 1];
          if (col - K - 1 >= 0)
            value -= mat[row][col - K - 1];
          if (col + K < cols)
            value += mat[row][col + K];

          list.Add(value);
        }

        dp.Add(list);
      }

      var ans = new List<List<int>>();

      for (var row = 0; row < rows; row++)
      {
        var list = new List<int>();

        for (var col = 0; col < cols; col++)
        {
          var sum = 0;

          for (var i = row - K; i <= row + K; i++)
          {
            if (i >= 0 && i < rows)
              sum += dp[i][col];
          }

          list.Add(sum);
        }

        ans.Add(list);
      }

      return ans.Select(l => l.ToArray()).ToArray();
    }
  }
}
