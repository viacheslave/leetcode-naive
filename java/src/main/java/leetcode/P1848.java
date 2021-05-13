package leetcode;

import java.util.ArrayList;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/minimum-distance-to-the-target-element/
 * Submission: https://leetcode.com/submissions/detail/491274029/
 */
public class P1848 {
    class Solution {
        public int getMinDistance(int[] nums, int target, int start) {
            var ans = Integer.MAX_VALUE;

            for (int i = 0; i < nums.length; i++) {
                if (nums[i] == target) {
                    ans = Math.min(ans, Math.abs(i - start));
                }
            }

            return ans;
        }
    }
}