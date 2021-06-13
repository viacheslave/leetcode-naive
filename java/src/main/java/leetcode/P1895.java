package leetcode;

import java.util.HashMap;

/*
 * Problem: https://leetcode.com/problems/largest-magic-square/
 * Submission: https://leetcode.com/submissions/detail/507318588/
 */
public class P1895 {
  class Solution {
    public int largestMagicSquare(int[][] grid) {
      var rows = grid.length;
      var cols = grid[0].length;

      var rowSum = new int[rows + 1][cols + 1];
      var colSum = new int[rows + 1][cols + 1];

      for (var i = 0; i < rows + 1; i++) {
        rowSum[i] = new int[cols + 1];
        colSum[i] = new int[cols + 1];
      }

      for (var i = 0; i < rows; i++)
        for (var j = 0; j < cols; j++)
          rowSum[i + 1][j + 1] = rowSum[i + 1][j] + grid[i][j];

      for (var j = 0; j < cols; j++)
        for (var i = 0; i < rows; i++)
          colSum[i + 1][j + 1] = colSum[i][j + 1] + grid[i][j];

      var ans = 1;

      for (var i = 0; i < rows; i++)
        for (var j = 0; j < cols; j++)
          ans = Math.max(ans, checkCorner(grid, i, j, ans, rowSum, colSum));

      return ans;
    }

    private int checkCorner(int[][] grid, int pi, int pj, int currentMax, int[][] rowSum, int[][] colSum) {
      var ans = currentMax;
      var rows = grid.length;
      var cols = grid[0].length;

      for (var length = currentMax + 1; ; length++) {
        if (pj + length > cols || pi + length > rows)
          break;

        var lx = rowSum[pi + 1][pj + length] - rowSum[pi + 1][pj];
        var ly = colSum[pi + length][pj + 1] - colSum[pi][pj + 1];

        if (lx == ly)
          if (checkSquare(grid, pi, pj, length, lx, rowSum, colSum))
            ans = length;
      }

      return ans;
    }

    private boolean checkSquare(int[][] grid, int pi, int pj, int length, int et, int[][] rowSum, int[][] colSum) {
      for (var r = pi; r < pi + length; r++) {
        var ll = rowSum[r + 1][pj + length] - rowSum[r + 1][pj];
        if (ll != et)
          return false;
      }

      for (var c = pj; c < pj + length; c++) {
        var ll = colSum[pi + length][c + 1] - colSum[pi][c + 1];
        if (ll != et)
          return false;
      }

      // diagonals
      var diag1 = 0;
      var diag2 = 0;
      for (var index = 0; index < length; index++) {
        diag1 += grid[pi + index][pj + index];
        diag2 += grid[pi + length - index - 1][pj + index];
      }

      if ((diag1 == et) && (diag2 == et))
        return true;

      return false;
    }
  }
}