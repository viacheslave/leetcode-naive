package leetcode;

import java.util.ArrayList;

/*
 * Problem: https://leetcode.com/problems/check-if-binary-string-has-at-most-one-segment-of-ones/
 * Submission: https://leetcode.com/submissions/detail/491290426/
 */
public class P1784 {
    class Solution {
        public boolean checkOnesSegment(String s) {
            var indices = new ArrayList<Integer>();

            for (var i = 0; i < s.length(); i++) {
                if (s.charAt(i) == '1')
                    indices.add(i);
            }

            var length = indices.get(indices.size() - 1) - indices.get(0) + 1;
            return length == indices.size();
        }
    }
}