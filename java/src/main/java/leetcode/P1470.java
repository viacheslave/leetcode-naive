package leetcode;

/*
* Problem: https://leetcode.com/problems/shuffle-the-array/
* Submission: https://leetcode.com/submissions/detail/351916857/
* */
public class P1470 {
    class Solution {
        public int[] shuffle(int[] nums, int n) {
            var ans = new int[n * 2];

            for (var index = 0; index < nums.length / 2; ++index) {
                ans[2 * index] = nums[index];
                ans[2 * index + 1] = nums[n + index];
            }

            return ans;
        }
    }
}
