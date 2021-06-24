package leetcode;

/*
 * Problem: https://leetcode.com/problems/largest-odd-number-in-string/
 * Submission: https://leetcode.com/submissions/detail/512657128/
 */
public class P1903 {
  class Solution {
    public String largestOddNumber(String num) {
      var li = num.length();
      for (var i = num.length() - 1; i >= 0; i--) {
        if (Integer.parseInt(String.valueOf(num.charAt(i))) % 2 == 1) {
          li = i;
          break;
        }
      }

      if (li == num.length())
        return "";

      return num.substring(0, li + 1);
    }
  }
}