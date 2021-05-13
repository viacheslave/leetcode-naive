package leetcode;

import java.util.*;

/**
 * Problem: https://leetcode.com/problems/maximum-average-pass-ratio/
 * Submission: https://leetcode.com/submissions/detail/476859076/
 */
public class P1792 {
    class Solution {
        public double maxAverageRatio(int[][] classes, int extraStudents) {
            var pq = new PriorityQueue<Ratio>(new RatioComparer());
            for (var i = 0; i < classes.length; ++i){
                pq.add(new Ratio(classes[i][0], classes[i][1]));
            }

            for (var i = 0; i < extraStudents; i++) {
                var item = pq.poll();
                item.Inc();
                pq.add(item);
            }

            var sum = 0d;
            for (var i = 0; i < classes.length; ++i) {
                var item = pq.poll();
                sum += 1.0 * item.Pass / item.Total;
            }

            return sum / classes.length;
        }

        class RatioComparer implements Comparator<Ratio> {

            @Override
            public int compare(Ratio o1, Ratio o2) {
                if (o1.Diff < o2.Diff)
                    return 1;
                if (o1.Diff > o2.Diff)
                    return -1;
                return 0;
            }
        }

        class Ratio {
            public int Pass;
            public int Total;
            public double Diff;

            public Ratio(int pass, int total) {
                Pass = pass;
                Total = total;
                Diff = 1.0 * (Pass + 1) / (Total + 1) - 1.0 * Pass / Total;
            }

            public void Inc() {
                Pass++;
                Total++;
                Diff = 1.0 * (Pass + 1) / (Total + 1) - 1.0 * Pass / Total;
            }
        }
    }
}
