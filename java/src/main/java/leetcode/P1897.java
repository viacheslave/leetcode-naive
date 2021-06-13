package leetcode;

import java.util.HashMap;

/*
 * Problem: https://leetcode.com/problems/redistribute-characters-to-make-all-strings-equal/
 * Submission: https://leetcode.com/submissions/detail/507342063/
 */
public class P1897 {
  class Solution {
    public boolean makeEqual(String[] words) {
      var hashMap = new HashMap<Character, Integer>();

      for (var word: words) {
        for (var ch: word.toCharArray()) {
          hashMap.putIfAbsent(ch, 0);
          hashMap.put(ch, hashMap.get(ch) + 1);
        }
      }

      return hashMap.entrySet().stream()
              .allMatch(e -> e.getValue() % words.length == 0);
    }
  }
}