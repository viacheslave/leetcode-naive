package leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;

/*
 * Problem: https://leetcode.com/problems/minimize-maximum-pair-sum-in-array/
 * Submission: https://leetcode.com/submissions/detail/500363373/
 */
public class P1877 {
  class Solution {
    public int minPairSum(int[] nums) {
      Arrays.sort(nums);

      var max = Integer.MIN_VALUE;
      for (var i = 0; i < nums.length / 2; i++) {
        max = Math.max(max, nums[i] + nums[nums.length - 1 - i]);
      }

      return max;
    }
  }
}