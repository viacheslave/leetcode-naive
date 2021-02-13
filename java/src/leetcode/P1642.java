package leetcode;

import java.util.PriorityQueue;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/furthest-building-you-can-reach/
 * Submission: https://leetcode.com/submissions/detail/415640041/
 */
class P1642 {
  class Solution {
    public int furthestBuilding(int[] heights, int bricks, int ladders) {
      var pq = new PriorityQueue<Integer>();

      var ans = 0;
      var sumH = 0;
      var sumLadders = 0;

      for (var i = 1; i < heights.length; i++) {
        var h = heights[i] - heights[i - 1];
        if (h <= 0) {
          ans = i;
          continue;
        }

        sumH += h;
        sumLadders += h;

        pq.add(h);

        if (pq.size() > ladders) {
          int poll = pq.poll();
          sumLadders -= poll;
        }

        if (sumH - sumLadders > bricks)
          break;

        ans = i;
      }

      return ans;
    }
  }
}