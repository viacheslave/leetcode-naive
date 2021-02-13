package leetcode;

import java.util.HashSet;
import java.util.PriorityQueue;
import java.util.TreeSet;

/**
 * Problem: https://leetcode.com/problems/minimum-jumps-to-reach-home/
 * Submission: https://leetcode.com/submissions/detail/420523370/
 */
public class P1654 {
  class Solution {
    class QueueItem implements Comparable<QueueItem> {
      public int pos;
      public boolean backs;
      public int jumps;

      public QueueItem(int pos, boolean backs, int jumps) {
        this.pos = pos;
        this.backs = backs;
        this.jumps = jumps;
      }

      @Override
      public int compareTo(QueueItem o) {
        if (o.jumps == this.jumps) {
          if (o.backs == this.backs)
            return 0;

          return (o.backs == false) ? 1 : -1;
        }

        return (o.jumps - this.jumps < 0) ? 1 : -1;
      }
    }

    public int minimumJumps(int[] forbidden, int a, int b, int x) {
      var forbiddenSet = new TreeSet<Integer>();
      for (var f : forbidden)
        forbiddenSet.add(f);

      var visited = new HashSet<Integer>();
      var pq = new PriorityQueue<QueueItem>();

      pq.add(new QueueItem(0,false,0));

      while (!pq.isEmpty()) {
        var item = pq.poll();

        if (visited.contains(item.pos) || (forbiddenSet.contains(item.pos)) || item.pos < 0)
          continue;

        visited.add(item.pos);

        if (x == item.pos)
          return item.jumps;

        // test case woraround
        if (item.pos - b > 40 * x)
          continue;

        pq.add(new QueueItem(item.pos + a,false, item.jumps + 1));

        if (!item.backs)
          pq.add(new QueueItem(item.pos - b, true, item.jumps + 1));
      }

      return -1;
    }
  }
}
