package leetcode;

/*
 * Problem: https://leetcode.com/problems/replace-all-digits-with-characters/
 * Submission: https://leetcode.com/submissions/detail/491283789/
 */
public class P1844 {
    class Solution {
        public String replaceDigits(String s) {
            var str = new StringBuilder(s);

            for (var i = 1; i < s.length(); i += 2) {
                var ch = s.charAt(i - 1);
                var replacementCode = (int)ch + Integer.parseInt(Character.toString(s.charAt(i)));
                var replCh = (char)replacementCode;

                str.replace(i, i + 1, Character.toString(replCh));
            }

            return str.toString();
        }
    }
}