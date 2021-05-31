package leetcode;

import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/substrings-of-size-three-with-distinct-characters/
 * Submission: https://leetcode.com/submissions/detail/500388825/
 */
public class P1876 {
  class Solution {
    public int countGoodSubstrings(String s) {
      var ans = 0;

      for (var i = 0; i < s.length() - 2; i++) {
        var str = s.substring(i, i + 3);
        var l = str.chars().boxed().collect(Collectors.toSet()).size();
        if (l == 3)
          ans++;
      }

      return ans;
    }
  }
}