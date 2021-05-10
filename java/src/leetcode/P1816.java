package leetcode;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/truncate-sentence/
 * Submission: https://leetcode.com/submissions/detail/491288436/
 */
public class P1816 {
    class Solution {
        public String truncateSentence(String s, int k) {
            var arr = Arrays.stream(s.split(" "))
              .limit(k)
              .collect(Collectors.joining(" "));

            return arr;
        }
    }
}