package leetcode;

import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/unique-length-3-palindromic-subsequences/
 * Submission: https://leetcode.com/submissions/detail/524861021/
 */
public class P1930 {
  class Solution {
    public int countPalindromicSubsequence(String s) {
      var prleft = new int[s.length()];
      var prright = new int[s.length()];

      var curleft = 0;
      var curright = 0;

      for (var i = 0; i < s.length(); i++) {
        var chleft = s.charAt(i) - 97;
        var chright = s.charAt(s.length() - 1 - i) - 97;

        prleft[i] = curleft | (1 << chleft);
        prright[i] = curright | (1 << chright);

        curleft = prleft[i];
        curright = prright[i];
      }

      var set = new HashSet<String>();

      for (var i = 1; i < s.length() - 1; i++) {
        var pivot = s.charAt(i);
        var l = prleft[i - 1];
        var r = prright[s.length() - 2 - i];

        var sum = l & r;

        var ch = 'a';

        while (sum > 0) {
          if (sum % 2 == 1) {
            set.add(String.copyValueOf(new char[] { ch, pivot, ch }));
          }

          sum >>= 1;
          ch++;
        }
      }

      return set.size();
    }
  }
}