package leetcode;

import java.util.Arrays;
import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/check-if-all-the-integers-in-a-range-are-covered/
 * Submission: https://leetcode.com/submissions/detail/507329477/
 */
public class P1893 {
  class Solution {
    public boolean isCovered(int[][] ranges, int left, int right) {
      var map = new HashSet<Integer>();

      for (var num = left; num <= right; num++)
        for (var range : ranges)
          if (range[0] <= num && num <= range[1])
            map.add(num);

      return map.size() == right - left + 1;
    }
  }
}