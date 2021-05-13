package leetcode;

import java.util.ArrayList;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/my-calendar-ii/submissions/
 * Submission: https://leetcode.com/submissions/detail/409503744/
 */
class P0731 {
    class MyCalendarTwo {

        private TreeMap<Integer, Integer> singled;
        private TreeMap<Integer, Integer> doubled;
    
        public MyCalendarTwo() {
          this.singled = new TreeMap<>();
          this.doubled = new TreeMap<>();
        }
        
        public boolean book(int start, int end) {
          var interval = new Range(start, end);
    
          // check doubled
          var floor = doubled.floorEntry(interval.start);
          var floorKey = floor == null ? 0 : floor.getKey();
          
          var doubledSubMap = doubled.tailMap(floorKey);
    
          for (var e : doubledSubMap.entrySet()) {
            if (intersect(interval, new Range(e.getKey(), e.getValue())))
              return false;
          }
          
          // add to singled
          floor = singled.floorEntry(interval.start);
          floorKey = floor == null ? 0 : floor.getKey();
    
          var singledSubMap = singled.tailMap(floorKey);
    
          var affectedKeys = new ArrayList<Integer>();
    
          var si = -1;
          var ei = -1;
    
          for (var e : singledSubMap.entrySet()) {
            if (intersect(interval, new Range(e.getKey(), e.getValue()))) {
              if (si == -1)
                si = ei = e.getKey().intValue();
              else
                ei = e.getKey().intValue(); 
                
              affectedKeys.add(e.getKey());
    
              var intersection = getIntersection(interval, new Range(e.getKey(), e.getValue()));
              doubled.put(intersection.start, intersection.end);
            }
          }
    
          if (singled.size() == 0 || si == -1) {
            singled.put(start, end);
            return true;
          }
    
          var newInterval = new Range(
            Math.min(interval.start, si), 
            Math.max(interval.end, singledSubMap.get(ei)));
    
          for (var a : affectedKeys)
            singled.remove(a);
    
          singled.put(newInterval.start, newInterval.end);
    
          return true;
        }
    
        private boolean intersect(Range interval, Range other) {
          return interval.start < other.end && interval.end > other.start;
        }
    
        private Range getIntersection(Range interval, Range other) {
          return new Range(
            Math.max(interval.start, other.start),
            Math.min(interval.end, other.end)
          );
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
     * Your MyCalendarTwo object will be instantiated and called as such:
     * MyCalendarTwo obj = new MyCalendarTwo();
     * boolean param_1 = obj.book(start,end);
     */
}