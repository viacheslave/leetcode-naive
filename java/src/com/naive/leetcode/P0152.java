package com.naive.leetcode;

import java.util.HashSet;
import java.util.TreeMap;

/**
 * Problem: https://leetcode.com/problems/maximum-product-subarray/
 * Submission: https://leetcode.com/submissions/detail/394159399/
 */
public class P0152 {
    class Solution {
        public int maxProduct(int[] nums) {
            var dp = new int[nums.length];

            var ans = Integer.MIN_VALUE;

            for (var i =0; i < nums.length; i++) {
                dp[i] = nums[i];

                var max = dp[i];

                for (var j = 0; j < i; j++) {
                    dp[j] *= nums[i];
                    max = Math.max(max, dp[j]);
                }

                ans = Math.max(ans, max);
            }

            return ans;
        }
    }
}
