package leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/merge-triplets-to-form-target-triplet/
 * Submission: https://leetcode.com/submissions/detail/507339322/
 */
public class P1899 {
  class Solution {
    public boolean mergeTriplets(int[][] triplets, int[] target) {
      var m0 = 0;
      var m1 = 0;
      var m2 = 0;

      for (var tr : triplets) {
        if (target[0] == tr[0] || target[1] == tr[1] || target[2] == tr[2]) {
          var m00 = Math.max(m0, tr[0]);
          var m11 = Math.max(m1, tr[1]);
          var m22 = Math.max(m2, tr[2]);

          if (m00 <= target[0] && m11 <= target[1] && m22 <= target[2]) {
            m0 = m00; m1 = m11; m2 = m22;
          }
        }
      }

      return target[0] == m0 && target[1] == m1 && target[2] == m2;
    }
  }
}