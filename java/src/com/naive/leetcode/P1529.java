package com.naive.leetcode;

import java.util.BitSet;

/**
 * Problem: https://leetcode.com/problems/bulb-switcher-iv/
 * Submission: https://leetcode.com/submissions/detail/378305141/
 */
public class P1529 {
    class Solution {
        public int minFlips(String target) {
            var ans = 0;
            var index = 0;

            var arr = new BitSet(target.length());

            while (index < target.length()) {
                var targetIndex = target.charAt(index) != '0';

                if (targetIndex != arr.get(index)) {
                    arr.flip(index, target.length() - 1);
                    ans++;
                }
            }

            return ans;
        }
    }
}
