package leetcode;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.TreeMap;

/**
 * Problem: https://leetcode.com/problems/find-latest-group-of-size-m/
 * Submission: https://leetcode.com/submissions/detail/385796430/
 */
public class P1562 {
    class Solution {
        public int findLatestStep(int[] arr, int m) {
            var ans = -1;
            var treeMap = new TreeMap<Integer, Integer>();

            var ms = new HashSet<Integer>();

            for (var i = 0; i < arr.length; i++) {
                var index = arr[i] - 1;

                var floor = treeMap.floorEntry(index);
                var ceiling = treeMap.ceilingEntry(index);

                var connectToFloor = floor != null && floor.getKey() + floor.getValue() == index;
                var connectToCeiling = ceiling != null && ceiling.getKey() - 1 == index;

                if (connectToFloor && connectToCeiling) {
                    treeMap.put(floor.getKey(), floor.getValue() + ceiling.getValue() + 1);

                    if (ceiling.getValue() == m) ms.remove(ceiling.getKey());
                    if (floor.getValue() == m) ms.remove(floor.getKey());
                    if (floor.getValue() + ceiling.getValue() + 1 == m) ms.add(floor.getKey());

                    treeMap.remove(ceiling.getKey());
                } else if (connectToFloor) {
                    treeMap.put(floor.getKey(), floor.getValue() + 1);

                    if (floor.getValue() == m) ms.remove(floor.getKey());
                    if (floor.getValue() + 1 == m) ms.add(floor.getKey());
                } else if (connectToCeiling) {
                    treeMap.put(index, ceiling.getValue() + 1);

                    if (ceiling.getValue() == m) ms.remove(ceiling.getKey());
                    if (ceiling.getValue() + 1 == m) ms.add(index);

                    treeMap.remove(ceiling.getKey());
                } else {
                    treeMap.put(index, 1);
                    if (1 == m) {
                        ms.add(index);
                    }
                }

                if (ms.size() > 0)
                    ans = i;
            }

            if (ans >= 0)
                ans++;

            return ans;
        }
    }
}
