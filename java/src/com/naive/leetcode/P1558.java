package com.naive.leetcode;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

/**
 * Problem: https://leetcode.com/problems/minimum-numbers-of-function-calls-to-make-target-array/
 * Submission: https://leetcode.com/submissions/detail/385308073/
 */
public class P1558 {
    class Solution {
        public int minOperations(int[] nums) {
            var ans = 0;

            while (true) {
                var ops = process(nums);
                ans += ops;

                if (ops == 0)
                    break;
            }

            return ans;
        }

        private int process(int[] nums) {
            var ops = 0;

            for (var i = 0; i < nums.length; i++) {
                if (nums[i] % 2 == 1) {
                    ops++;
                    nums[i]--;
                }
            }

            if (ops != 0)
                return ops;

            var allzeros = true;
            for (var i = 0; i < nums.length; i++) {
                nums[i] /= 2;
                if (nums[i] != 0)
                    allzeros = false;
            }

            if (allzeros)
                return 0;

            return 1;
        }
    }
}
