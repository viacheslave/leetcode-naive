package vzh;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/data-stream-as-disjoint-intervals/
 * Submission: https://leetcode.com/submissions/detail/413056773/
 */
class P0352 {
  class SummaryRanges {

    TreeMap<Integer, Integer> map = new TreeMap<Integer, Integer>();

    /**
     * Initialize your data structure here.
     */
    public SummaryRanges() {
    }

    public void addNum(int val) {
      var floor = map.floorEntry(val);
      var ceil = map.ceilingEntry(val);

      // range exists
      if (floor != null && floor.getValue() >= val)
        return;

      var start = val;
      var end = val;

      if (floor != null && floor.getValue().intValue() == val - 1) {
        start = floor.getKey();
        map.remove(floor.getKey());
      }

      if (ceil != null && ceil.getKey() == val + 1) {
        end = ceil.getValue();
        map.remove(ceil.getKey());
      }

      map.put(start, end);
    }

    public int[][] getIntervals() {
      var ans = new int[map.size()][];
      var index = 0;

      for (var entry : map.entrySet())
      {
        var inner = new int[2];
        inner[0] = entry.getKey();
        inner[1] = entry.getValue();

        ans[index++] = inner;
      }

      return ans;
    }
  }

/**
 * Your SummaryRanges object will be instantiated and called as such:
 * SummaryRanges obj = new SummaryRanges();
 * obj.addNum(val);
 * int[][] param_2 = obj.getIntervals();
 */
}