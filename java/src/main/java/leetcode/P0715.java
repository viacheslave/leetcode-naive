package leetcode;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.TreeMap;

/**
 * Problem: https://leetcode.com/problems/range-module/
 * Submission: https://leetcode.com/submissions/detail/413074754/
 */
public class P0715 {
  class RangeModule {

    TreeMap<Integer, Integer> map = new TreeMap<>();

    public RangeModule() {
    }

    public void addRange(int left, int right) {
      var start = left;
      var end = right;

      var range = new Range(left, right);

      var rem = new ArrayList<Integer>();

      for (var entry : map.entrySet()) {
        if (intersect(range, new Range(entry.getKey(), entry.getValue()))) {
          start = Math.min(start, Math.min(range.start, entry.getKey()));
          end = Math.max(end, Math.max(range.end, entry.getValue()));

          rem.add(entry.getKey());
        }
      }

      for (var a : rem) {
        map.remove(a);
      }

      var floor = map.floorEntry(start);
      var ceil = map.ceilingEntry(end);

      if (floor != null && floor.getValue().intValue() == start - 1) {
        start = floor.getKey();
        map.remove(floor.getKey());
      }

      if (ceil != null && ceil.getKey() == end + 1) {
        end = ceil.getValue();
        map.remove(ceil.getKey());
      }

      map.put(start, end);
    }

    public boolean queryRange(int left, int right) {
      var floor = map.floorEntry(left);

      if (floor != null && floor.getValue() >= right)
        return true;

      return false;
    }

    public void removeRange(int left, int right) {
      var range = new Range(left, right);

      var rem = new ArrayList<Integer>();
      var add = new ArrayList<Range>();

      for (var key : map.keySet()) {
        var value = map.get(key);

        if (!intersect(new Range(key, value), range))
          continue;

        if (key >= left && value <= right) {
          rem.add(key);
          continue;
        }

        if (key < left && value > right) {
          rem.add(key);
          add.add(new Range(key, left));
          add.add(new Range(right, value));
          continue;
        }

        if (key < left) {
          rem.add(key);
          add.add(new Range(key, left));
        }

        if (value > right) {
          rem.add(key);
          add.add(new Range(right, value));
        }
      }

      for (var a : rem) {
        map.remove(a);
      }

      for (var a : add) {
        map.put(a.start, a.end);
      }
    }

    private boolean intersect(Range interval, Range other) {
      return interval.start < other.end && interval.end > other.start;
    }

    private class Range {
      public int start;
      public int end;

      public Range(int start, int end) {
        this.start = start;
        this.end = end;
      }
    }
  }

/**
 * Your RangeModule object will be instantiated and called as such:
 * RangeModule obj = new RangeModule();
 * obj.addRange(left,right);
 * boolean param_2 = obj.queryRange(left,right);
 * obj.removeRange(left,right);
 */
}
