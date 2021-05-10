package leetcode;

/*
 * Problem: https://leetcode.com/problems/sign-of-the-product-of-an-array/
 * Submission: https://leetcode.com/submissions/detail/491202984/
 */
public class P1822 {
    class Solution {
        public int arraySign(int[] nums) {
            var pr = 1;
            for (var n : nums) {
                if (n == 0)
                    return 0;
                if (n < 0)
                    pr = -1 * pr;
            }

            return pr;
        }
    }
}