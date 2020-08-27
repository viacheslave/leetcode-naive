package com.naive.leetcode;

import java.util.HashMap;
import java.util.TreeMap;

/**
 * Problem: https://leetcode.com/problems/find-right-interval/
 * Submission: https://leetcode.com/submissions/detail/387098803/
 */
public class P0436 {
    class Solution {
        public int[] findRightInterval(int[][] intervals) {
            var treeMap = new TreeMap<Integer, Integer>();
            var indexMap = new HashMap<Integer, Integer>();

            for (int i = 0; i < intervals.length; i++) {
                int[] interval = intervals[i];
                treeMap.put(interval[0], interval[1]);
                indexMap.put(interval[0], i);
            }

            var ans = new int[intervals.length];

            for (int i = 0; i < intervals.length; i++) {
                int[] interval = intervals[i];
                var rightEdge = interval[1];

                if (treeMap.containsKey(rightEdge))
                    ans[i] = indexMap.get(rightEdge);
                else {
                    var ceiling = treeMap.ceilingEntry(rightEdge);
                    if (ceiling != null) {
                        var key = ceiling.getKey();
                        var index = indexMap.get(key);
                        ans[i] = index;
                    } else {
                        ans[i] = -1;
                    }
                }
            }

            return ans;
        }
    }
}
