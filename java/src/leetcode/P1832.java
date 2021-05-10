package leetcode;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/check-if-the-sentence-is-pangram/
 * Submission: https://leetcode.com/submissions/detail/491287098/
 */
public class P1832 {
    class Solution {
        public boolean checkIfPangram(String sentence) {

            var frequentChars = Arrays
              .stream(sentence.toLowerCase().split(""))
              .collect(
                Collectors.groupingBy(c -> c,
                  Collectors.counting()));

            return frequentChars.size() == 26;
        }
    }
}