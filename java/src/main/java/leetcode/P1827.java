package leetcode;

/*
 * Problem: https://leetcode.com/problems/minimum-operations-to-make-the-array-increasing/
 * Submission: https://leetcode.com/submissions/detail/491289313/
 */
public class P1827 {
    class Solution {
        public int minOperations(int[] nums) {
            var ans = 0;

            for (var i = 1; i < nums.length; i++) {
                if (nums[i] <= nums[i - 1]) {
                    ans += nums[i - 1] - nums[i] + 1;
                    nums[i] = nums[i - 1] + 1;
                }
            }

            return ans;
        }
    }
}