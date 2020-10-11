using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-valid-matrix-given-row-and-column-sums/
	///		Submission: https://leetcode.com/submissions/detail/407397313/
	/// </summary>
	internal class P1605
	{
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
    {
      var rowMap = rowSum.Select((e, i) => (e, i))
          .OrderByDescending(x => x.e)
          .ToList();

      var colMap = colSum.Select((e, i) => (e, i))
          .OrderByDescending(x => x.e)
          .ToList();

      var ans = new int[rowMap.Count][];

      for (var i = 0; i < rowMap.Count; i++)
        ans[i] = new int[colMap.Count];

      while (rowMap.Count > 0 && colMap.Count > 0)
      {
        var minRow = rowMap[^1];
        var minCol = colMap[^1];

        var value = Math.Min(minRow.e, minCol.e);
        ans[minRow.i][minCol.i] = value;

        if (minRow.e == value)
        {
          for (var idx = 0; idx < colMap.Count; idx++)
          {
            var col = colMap[idx].i;

            if (minCol.i != col)
              ans[minRow.i][col] = 0;
          }

          rowMap.RemoveAt(rowMap.Count - 1);
        }

        if (minCol.e == value)
        {
          for (var idx = 0; idx < rowMap.Count; idx++)
          {
            var row = rowMap[idx].i;

            if (minRow.i != row)
              ans[row][minCol.i] = 0;
          }

          colMap.RemoveAt(colMap.Count - 1);
        }

        if (minRow.e == value && minCol.e == value)
          continue;

        if (minRow.e == value)
          colMap[^1] = (colMap[^1].e - value, colMap[^1].i);

        if (minCol.e == value)
          rowMap[^1] = (rowMap[^1].e - value, rowMap[^1].i);
      }

      return ans;
    }
  }
}
