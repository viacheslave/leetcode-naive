package leetcode;

import java.util.HashSet;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/maximum-number-of-words-you-can-type/
 * Submission: https://leetcode.com/submissions/detail/524864578/
 */
public class P1935 {
  class Solution {
    public int canBeTypedWords(String text, String brokenLetters) {
      var set = brokenLetters.chars()
              .mapToObj(c -> (char)c)
              .collect(Collectors.toUnmodifiableSet());

      var words = text.split(" ");

      var ans = 0;

      for (var word : words) {
        for (var ch : word.toCharArray()) {
          if (set.contains(ch)) {
            ans++;
            break;
          }
        }
      }

      return words.length - ans;
    }
  }
}