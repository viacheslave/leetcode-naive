package com.naive.leetcode;

import java.util.Arrays;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

/**
 * Problem: https://leetcode.com/problems/least-number-of-unique-integers-after-k-removals/
 * Submission: https://leetcode.com/submissions/detail/378416132/
 */
public class P1481 {
    class Solution {
        public int findLeastNumOfUniqueInts(int[] arr, int k) {
            var list = Arrays.stream(arr).boxed().collect(Collectors.toList());

            var result =
                list.stream().collect(
                    Collectors.groupingBy(
                        Function.identity(), Collectors.counting()
                    )
                );

            LinkedHashMap<Integer, Long> map = new LinkedHashMap<>();

            result.entrySet().stream()
                .sorted(Map.Entry.<Integer, Long>comparingByValue())
                .forEachOrdered(e -> map.put(e.getKey(), e.getValue()));

            var entrySet = map.entrySet();
            var removed = 0;

            for (var entry: entrySet) {
                var count = entry.getValue();

                if (k < count)
                    return entrySet.size() - removed;

                k -= count;
                removed++;
            }

            return map.size() - removed;
        }
    }
}
