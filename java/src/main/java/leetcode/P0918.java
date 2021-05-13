package leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Problem: https://leetcode.com/problems/maximum-sum-circular-subarray/
 * Submission: https://leetcode.com/submissions/detail/412272531/
 */
public class P0918 {
    public class Solution {
        public int maxSubarraySumCircular(int[] A) {
            var prefixSum = new int[A.length + 1];
            var suffixSum = new int[A.length + 1];

            // pre-calculate sums
            for (var i = 0; i < A.length; i++)
                prefixSum[i + 1] += prefixSum[i] + A[i];

            for (var i = A.length - 1; i >= 0; i--)
                suffixSum[A.length - i] += suffixSum[A.length - i - 1] + A[i];

            // regular, use DP
            var dp = new int[A.length];
            dp[0] = A[0];

            var max = dp[0];

            for (var i = 1; i < A.length; i++) {
                dp[i] = Math.max(dp[i - 1] + A[i], A[i]);
                max = Math.max(max, dp[i]);
            }

            // use prefix and suffix sums in O(n)
            for (var i = 1; i < A.length; i++) 
                dp[i] = Math.max(prefixSum[i] + A[i], dp[i - 1]);
            
            for (var i = 1; i < A.length; i++) {
                max = Math.max(max, suffixSum[i] + dp[A.length - i - 1]);
            }

            return max;
        }
    }
}
