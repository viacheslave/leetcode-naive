package leetcode;

import java.util.Collections;
import java.util.PriorityQueue;

/*
 * Problem: https://leetcode.com/problems/k-th-smallest-prime-fraction/
 * Submission: https://leetcode.com/submissions/detail/416041525/
 */
class P0786 {
  class Solution {
    class Range implements Comparable<Range> {
      public int p;
      public int q;
      public double v;

      public Range(int p, int q, double v) {
        this.p = p;
        this.q = q;
        this.v = v;
      }

      @Override
      public int compareTo(Range o) {
        if (o.v - this.v > 0)
          return 1;
        if (o.v - this.v < 0)
          return -1;
        return 0;
      }
    }

    public int[] kthSmallestPrimeFraction(int[] A, int K) {
      var pq = new PriorityQueue<Range>(Collections.reverseOrder());

      for (var i = 0; i < A.length - 1; i++)
        pq.add(new Range(i, A.length - 1, 1.0 * A[i] / A[A.length - 1]));

      for (var i = 0; i < K - 1; i++) {
        var poll = pq.poll();

        var qnext = poll.q - 1;
        if (qnext != poll.p)
          pq.add(new Range(poll.p, qnext, 1.0 * A[poll.p] / A[qnext]));
      }

      var el = pq.poll();
      var ans = new int[] { A[el.p], A[el.q] };

      return ans;
    }
  }
}