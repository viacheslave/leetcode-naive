package leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/find-the-student-that-will-replace-the-chalk/
 * Submission: https://leetcode.com/submissions/detail/507289236/
 */
public class P1894 {
  class Solution {
    public int chalkReplacer(int[] chalk, int k) {
      var kk = k % Arrays.stream(chalk).asLongStream().sum();

      for (var i = 0; ; i++) {
        var index = i % chalk.length;
        if (kk < chalk[index])
          return index;
        kk -= chalk[index];
      }
    }
  }
}