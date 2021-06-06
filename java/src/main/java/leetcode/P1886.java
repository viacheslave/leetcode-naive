package leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/
 * Submission: https://leetcode.com/submissions/detail/503956152/
 */
public class P1886 {
  class Solution {
    public boolean findRotation(int[][] mat, int[][] target) {
      if (eq(mat, target))
        return true;

      var next = rotate90(mat);
      if (eq(next, target))
        return true;

      next = rotate90(next);
      if (eq(next, target))
        return true;

      next = rotate90(next);
      if (eq(next, target))
        return true;

      return false;
    }

    private boolean eq(int[][] mat, int[][] target) {
      for (var i = 0; i < mat.length; i++)
        for (var j = 0; j < mat.length; j++)
          if (mat[i][j] != target[i][j])
            return false;

      return true;
    }

    private int[][] rotate90(int[][] mat) {
      var ans = new int[mat.length][mat.length];

      for (var i = 0; i < mat.length; i++)
        for (var j = 0; j < mat.length; j++)
          ans[i][j] = mat[j][mat.length - i - 1];

      return ans;
    }
  }
}