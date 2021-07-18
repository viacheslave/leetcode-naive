using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-a-peak-element-ii/
  ///    Submission: https://leetcode.com/submissions/detail/524597393/
  /// </summary>
  internal class P1901
  {
    public class Solution
    {
      public int[] FindPeakGrid(int[][] mat)
      {
        var rows = mat.Length + 2;
        var cols = mat[0].Length + 2;
        var arr = new int[rows, cols];

        for (var i = 0; i < rows; i++)
        {
          for (var j = 0; j < cols; j++)
          {
            if (i == 0 || j == 0 || i == rows - 1 || j == cols - 1)
            {
              arr[i, j] = -1;
              continue;
            }

            arr[i, j] = mat[i - 1][j - 1];
          }
        }

        for (var i = 1; i < rows - 1; i++)
        {
          var ans = SearchRec(arr, i, 1, cols - 2);
          if (ans.HasValue)
            return new[] { i - 1, ans.Value - 1 };
        }

        return null;
      }

      private int? SearchRec(int[,] arr, int row, int start, int end)
      {
        if (start > end)
          return default;

        var mid = (start + end) / 2;

        if (arr[row, mid] > arr[row, mid - 1] && arr[row, mid] > arr[row, mid + 1] &&
            arr[row, mid] > arr[row - 1, mid] && arr[row, mid] > arr[row + 1, mid])
          return mid;

        if (arr[row, mid - 1] < arr[row, mid] && arr[row, mid] < arr[row, mid + 1])
          return SearchRec(arr, row, mid + 1, end);

        if (arr[row, mid - 1] > arr[row, mid] && arr[row, mid] > arr[row, mid + 1])
          return SearchRec(arr, row, start, mid - 1);

        return SearchRec(arr, row, mid + 1, end) ?? SearchRec(arr, row, start, mid - 1);
      }
    }
  }
}
