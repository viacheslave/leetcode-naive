package leetcode;

import java.util.PriorityQueue;

/**
 * Problem: https://leetcode.com/problems/super-ugly-number/
 * Submission: https://leetcode.com/submissions/detail/413459638/
 */
public class P0313 {
  class Solution {
    public int nthSuperUglyNumber(int n, int[] primes) {
      var pq = new PriorityQueue<Long>();

      for (var p : primes) {
        pq.add(1L * p);
      }

      var ans = 1L;

      for (var i = 1; i < n; i++) {
        var el = pq.poll();
        if (el == ans) {
          i--;
          continue;
        }

        ans = el;

        var startIndex = -1;

        for (var j = 0; j < primes.length; j++) {
          if (ans % primes[j] == 0) {
            startIndex = j;
            break;
          }
        }

        for (var s = startIndex; s < primes.length; s++) {
          pq.add(ans * primes[s]);
        }
      }

      return (int)ans;
    }
  }
}
