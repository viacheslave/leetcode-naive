package leetcode;

import java.util.ArrayList;

/*
 * Problem: https://leetcode.com/problems/check-if-one-string-swap-can-make-strings-equal/
 * Submission: https://leetcode.com/submissions/detail/491292569/
 */
public class P1790 {
    class Solution {
        public boolean areAlmostEqual(String s1, String s2) {
            var diff = new ArrayList<Integer>();

            for (var i = 0; i < s1.length(); ++i) {
                if (s1.charAt(i) != s2.charAt(i))
                    diff.add(i);
            }

            if (diff.size() == 0)
                return true;

            if (diff.size() != 2)
                return false;

            var i1 = diff.get(0);
            var i2 = diff.get(1);

            return
              s1.charAt(i1) == s2.charAt(i2) &&
                s1.charAt(i2) == s2.charAt(i1);
        }
    }
}