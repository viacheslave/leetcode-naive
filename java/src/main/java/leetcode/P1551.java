package leetcode;

/**
 * Problem: https://leetcode.com/problems/minimum-operations-to-make-array-equal/
 * Submission: https://leetcode.com/submissions/detail/381660673/
 */
public class P1551 {
    class Solution {
        public int minOperations(int n) {
            if (n <= 1)
                return 0;

            var mid = n / 2;
            var ans = 0;

            if (n % 2 == 1) {
                for (var i = 0; i < mid; i++)
                    ans += 2 * (i + 1);
            } else {
                for (var i = 0; i < mid; i++)
                    ans += 2 * i + 1;
            }

            return ans;
        }
    }
}
