package leetcode;

import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/maximum-value-after-insertion/
 * Submission: https://leetcode.com/submissions/detail/500359282/
 */
public class P1881 {
  class Solution {
    public String maxValue(String n, int x) {
      var sb = new StringBuilder(n);
      var negative = sb.charAt(0) == '-';
      var index = -1;
      var start = negative ? 1 : 0;

      for (var i = start; i < sb.length(); i++) {
        var num = Integer.parseInt(sb.substring(i, i + 1));
        if ((!negative && x > num) || (negative && x < num)) {
          index = i;
          break;
        }
      }

      if (index != -1) {
        sb.insert(index, x);
        return sb.toString();
      }

      sb.append(x);
      return sb.toString();
    }
  }
}