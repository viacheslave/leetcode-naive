package com.naive.leetcode;

/**
 * Problem: https://leetcode.com/problems/broken-calculator/
 * Submission: https://leetcode.com/submissions/detail/378497410/
 */
public class P0991 {
    class Solution {
        public int brokenCalc(int X, int Y) {
            var ans = 0;
            var current = Y;

            while (X != current)
            {
                if (current % 2 == 1)
                {
                    current++;
                    ans++;
                    continue;
                }

                if (current >= X && X < current)
                {
                    current /= 2;
                    ans++;
                    continue;
                }

                current++;
                ans++;
            }

            return ans;
        }
    }
}
