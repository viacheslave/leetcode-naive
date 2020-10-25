package leetcode;

/**
 * Problem: https://leetcode.com/problems/find-kth-bit-in-nth-binary-string/
 * Submission: https://leetcode.com/submissions/detail/378325866/
 */
public class P1545 {
    class Solution {
        public char findKthBit(int n, int k) {
            var Sn = BuildS(n);

            return Sn[k - 1] == true ? '1' : '0';
        }

        private boolean[] BuildS(int n) {
            if (n == 1) {
                return new boolean[] {false};
            }

            var list = BuildS(n - 1);

            var newList = new boolean[list.length * 2 + 1];

            for (var i = 0; i < list.length; i++) {
                newList[i] = list[i];
                newList[newList.length - 1 - i] = !list[i];
            }

            newList[list.length] = true;
            return newList;
        }
    }
}
