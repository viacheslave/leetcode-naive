using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-submatrices-with-all-ones/
  ///    Submission: https://leetcode.com/submissions/detail/414242063/
  /// </summary>
  internal class P1504
  {
    public class Solution
    {
      public int NumSubmat(int[][] mat)
      {
        var rows = mat.Length;
        var cols = mat[0].Length;

        // calculate that nums arrays for every ith row
        var nums = new int[rows, cols];

        for (var i = 0; i < rows; i++)
        {
          for (var j = 0; j < cols; j++)
          {
            if (j == 0)
              nums[i, j] = mat[i][j];
            else
              nums[i, j] = mat[i][j] == 1
                ? nums[i, j - 1] + 1
                : 0;
          }
        }

        // O(N^3)
        // every element is the sum of current + all minimums for every rows above
        var ans = new int[rows, cols];

        for (var i = 0; i < rows; i++)
        {
          for (var j = 0; j < cols; j++)
          {
            if (i == 0)
            {
              ans[i, j] = nums[i, j];
              continue;
            }

            ans[i, j] = nums[i, j];

            var min = nums[i, j];
            for (var k = i - 1; k >= 0; k--)
            {
              min = Math.Min(min, nums[k, j]);
              ans[i, j] += min;
            }
          }
        }

        // ans is total sum
        var res = 0;
        for (var i = 0; i < rows; i++)
          for (var j = 0; j < cols; j++)
            res += ans[i, j];

        return res;
      }
    }
  }
}
