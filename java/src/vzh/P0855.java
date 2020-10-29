package vzh;

import java.util.Collections;
import java.util.PriorityQueue;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/exam-room/
 * Submission: https://leetcode.com/submissions/detail/414597024/
 */
class P0855 {
  class ExamRoom {

    PriorityQueue<Range> _gaps = new PriorityQueue<>(Collections.reverseOrder());
    TreeMap<Integer, Range> _places = new TreeMap<>();
    int n;

    public ExamRoom(int N) {
      n = N;

      _gaps.add(new Range(-1, N, N));
    }

    public int seat() {
      Range range = _gaps.poll();
      var s = range.mid;

      var left = new Range(range.from, s, this.n);
      var right = new Range(s, range.to, this.n);

      _gaps.add(left);
      _gaps.add(right);

      _places.put(left.from, left);
      _places.put(right.from, right);
      return s;
    }

    public void leave(int p) {
      var floorEntry = _places.floorEntry(p - 1);
      var ceilEntry = _places.floorEntry(p);

      if (p != 0) {
        _places.remove(floorEntry.getKey());
        _gaps.remove(floorEntry.getValue());
      }

      if (p != this.n - 1) {
        _places.remove(ceilEntry.getKey());
        _gaps.remove(ceilEntry.getValue());
      }

      var range = new Range(floorEntry.getValue().from, ceilEntry.getValue().to, this.n);

      _gaps.add(range);
      _places.put(floorEntry.getKey(), range);
    }

    class Range implements Comparable<Range> {
      public int rank;
      public int mid;
      public int from;
      public int to;

      public Range(int from, int to, int n) {
        this.from = from;
        this.to = to;

        if (from == -1 && to == n) {
          mid = 0;
          rank = n;
        } else if (from == -1) {
          mid = 0;
          rank = to;
        } else if (to == n) {
          mid = n - 1;
          rank = n - from - 1;
        } else {
          mid = (from + to) / 2;
          rank = (from + to) / 2 - from;
        }
      }

      @Override
      public int compareTo(Range o) {
        var r = this.rank - o.rank;
        if (r == 0) {
          return o.from - this.from;
        }
        return r;
      }
    }
  }

  /**
   * Your ExamRoom object will be instantiated and called as such:
   * ExamRoom obj = new ExamRoom(N);
   * int param_1 = obj.seat();
   * obj.leave(p);
   */
}