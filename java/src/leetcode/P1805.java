package leetcode;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/number-of-different-integers-in-a-string/
 * Submission: https://leetcode.com/submissions/detail/491297977/
 */
public class P1805 {
    class Solution {
        public int numDifferentIntegers(String word) {
            var str = new StringBuilder(word);

            for (var i = 0; i < word.length(); ++i) {
                if (!Character.isDigit(str.charAt(i)))
                    str.replace(i, i+1, " ");
                else
                    str.replace(i, i+1, Character.toString(str.charAt(i)));
            }

            var s = str.toString();
            var parts = s.split("\\s");

            var numbers = Arrays.stream(parts)
              .filter(i -> !i.isEmpty())
              .map(i -> i.replaceAll("^0+", ""))
              .collect(Collectors.toSet());

            return numbers.size();
        }
    }
}