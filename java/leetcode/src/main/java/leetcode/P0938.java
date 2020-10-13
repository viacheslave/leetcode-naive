package leetcode;

import java.util.HashMap;
import java.util.TreeSet;

/**
 * Problem: https://leetcode.com/problems/minimum-cost-for-tickets/
 * Submission: https://leetcode.com/submissions/detail/386261402/
 */
public class P0938 {
    class Solution {
        public int mincostTickets(int[] days, int[] costs) {
            var map = new TreeSet<Integer>();
            var dp = new HashMap<Integer, Integer>();

            for (var day : days) {
                map.add(day);
            }

            return min(map, map.first(), dp, costs);
        }

        private int min(TreeSet<Integer> map, int day, HashMap<Integer, Integer> dp, int[] costs) {
            if (day > 365)
                return 0;

            int start = getStartDay(map, day);
            if (start > 365)
                return 0;

            if (dp.containsKey(start))
                return dp.get(start);

            var min1 = costs[0] + min(map, start + 1, dp, costs);
            var min7 = costs[1] + min(map, start + 7, dp, costs);
            var min30 = costs[2] + min(map, start + 30, dp, costs);

            var min = Math.min(Math.min(min1, min7), min30);

            dp.put(start, min);
            return min;
        }

        private int getStartDay(TreeSet<Integer> map, int day) {
            if (map.contains(day))
                return day;

            var ceiling = map.ceiling(day);
            if (ceiling == null) {
                return Integer.MAX_VALUE;
            }

            return ceiling.intValue();
        }
    }
}
