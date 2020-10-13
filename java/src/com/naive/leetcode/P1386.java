package com.naive.leetcode;

import java.util.HashMap;
import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/cinema-seat-allocation/
 * Submission: https://leetcode.com/submissions/detail/314593738/
 */
class P1386 {
    class Solution {
        public int maxNumberOfFamilies(int n, int[][] reservedSeats) {
            var map = new HashMap<Integer, HashSet<Integer>>();

            for (int i = 0; i < reservedSeats.length; i++) {
                var row = reservedSeats[i][0];
                var seat = reservedSeats[i][1];

                if (!map.containsKey(row))
                    map.put(row, new HashSet<Integer>());

                map.get(row).add(seat);
            }

            var ans = 0;

            for (Integer key : map.keySet()) {
                ans += getAllocated(map.get(key));
            }

            ans += (n - map.size()) * 2;

            return ans;
        }

        private int getAllocated(HashSet<Integer> seats) {
            var leftIsle =
                    !seats.contains(2) &&
                    !seats.contains(3) &&
                    !seats.contains(4) &&
                    !seats.contains(5);

            var rightIsle =
                    !seats.contains(6) &&
                    !seats.contains(7) &&
                    !seats.contains(8) &&
                    !seats.contains(9);

            if (leftIsle && rightIsle)
                return 2;

            if (leftIsle || rightIsle)
                return 1;

            var center =
                    !seats.contains(4) &&
                    !seats.contains(5) &&
                    !seats.contains(6) &&
                    !seats.contains(7);

            if (center)
                return 1;

            return 0;
        }
    }
}