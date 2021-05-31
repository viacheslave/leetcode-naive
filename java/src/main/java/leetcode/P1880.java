package leetcode;

import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/check-if-word-equals-summation-of-two-words/
 * Submission: https://leetcode.com/submissions/detail/500392953/
 */
public class P1880 {
  class Solution {
    public boolean isSumEqual(String firstWord, String secondWord, String targetWord) {
      return getInt(firstWord) + getInt(secondWord) == getInt(targetWord);
    }

    private int getInt(String str) {
      var s1 = str.chars()
              .map(ch -> ch - 97)
              .boxed()
              .map(ch -> ch.toString())
              .collect(Collectors.joining());

      return Integer.parseInt(s1);
    }
  }
}