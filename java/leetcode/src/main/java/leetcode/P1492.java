package leetcode;

/**
 * Problem: https://leetcode.com/problems/the-kth-factor-of-n/
 * Submission: https://leetcode.com/submissions/detail/374941591/
 */
public class P1492 {
    class Solution {
        public int kthFactor(int n, int k) {
            var th = 0;

            for (int i = 1; i <= n; i++) {
                if (n % i == 0) {
                    th++;
                    if (th == k)
                        return i;
                }
            }

            return -1;
        }
    }
}
