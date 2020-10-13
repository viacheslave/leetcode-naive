package com.naive.leetcode;

import java.util.Arrays;

/**
 * Problem: https://leetcode.com/problems/maximum-number-of-coins-you-can-get/
 * Submission: https://leetcode.com/submissions/detail/385750904/
 */
public class P1561 {
    class Solution {
        public int maxCoins(int[] piles) {
            Arrays.sort(piles);

            var ans = 0;

            for (var i = 0; i < piles.length / 3; i++) {
                var index = piles.length - 2 - 2 * i;
                ans += piles[index];
            }

            return ans;
        }
    }
}
