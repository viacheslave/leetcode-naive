package leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/reduction-operations-to-make-the-array-elements-equal/
 * Submission: https://leetcode.com/submissions/detail/503949030/
 */
public class P1887 {
  class Solution {
    public int reductionOperations(int[] nums) {
      Arrays.sort(nums);

      var ans = 0;
      for (var i = 1; i < nums.length; i++) {
        if (nums[i] != nums[ i - 1]) {
          ans += nums.length - i;
        }
      }

      return ans;
    }
  }
}