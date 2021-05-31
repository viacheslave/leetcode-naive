package leetcode;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/get-biggest-three-rhombus-sums-in-a-grid/
 * Submission: https://leetcode.com/submissions/detail/500383515/
 */
public class P1878 {
  class Solution {
    public int[] getBiggestThree(int[][] grid) {
      var rows = grid.length;
      var cols = grid[0].length;

      var sums = new ArrayList<Integer>();

      for (var r = 0; r < rows; r++) {
        for (var c = 0; c < cols; c++) {

          // r,c - start
          for (var l = 0; ; l += 2) {
            if (r + l >= rows || c + l >= cols)
              break;

            var perimeter = getPerimeter(grid, r, c, l);
            sums.add(perimeter);
          }
        }
      }

      var ans = sums.stream().distinct()
              .sorted(Comparator.reverseOrder())
              .limit(3)
              .mapToInt(c -> c.intValue())
              .toArray();

      return ans;
    }

    private int getPerimeter(int[][] grid, int r, int c, int l) {
      if (l == 0)
        return grid[r][c];

      var sum = 0;

      int sr = r;
      int sc = c + l / 2;

      for (var i = 0; i <= l / 2; i++) {
        sum += grid[sr + i][sc - i];
        sum += grid[sr + i][sc + i];
        sum += grid[sr + l - i][sc - i];
        sum += grid[sr + l - i][sc + i];
      }

      sum -= grid[r][c + l / 2];
      sum -= grid[r + l][c + l / 2];
      sum -= grid[r + l / 2][c];
      sum -= grid[r + l / 2][c + l];

      return sum;
    }
  }
}