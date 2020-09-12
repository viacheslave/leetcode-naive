package com.naive.leetcode;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.TreeMap;

/**
 * Problem: https://leetcode.com/problems/minimum-increment-to-make-array-unique/
 * Submission: https://leetcode.com/submissions/detail/394713855/
 */
public class P0945 {
    class TweetCounts {

        public int minIncrementForUnique(int[] A) {
            if (A.length <= 1)
                return 0;

            var map = new TreeMap<Integer, Integer>();

            for (var a : A) {
                map.putIfAbsent(a, 0);
                map.put(a, map.get(a) + 1);
            }

            var ans = 0;

            var entry = map.firstEntry();

            while (true) {
                if (entry.getValue().intValue() != 1) {
                    var incKey = entry.getKey() + 1;
                    map.putIfAbsent(incKey, 0);

                    ans += entry.getValue() - 1;
                    map.put(incKey, map.get(incKey) + entry.getValue() - 1);
                    map.put(entry.getKey(), 1);
                }

                entry = map.ceilingEntry(entry.getKey() + 1);
                if (entry == null)
                    break;
            }

            return ans;
        }
    }
}
