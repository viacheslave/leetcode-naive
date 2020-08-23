package com.naive.leetcode;

import java.util.ArrayList;
import java.util.BitSet;
import java.util.HashSet;
import java.util.List;

/**
 * Problem: https://leetcode.com/problems/minimum-number-of-vertices-to-reach-all-nodes/
 * Submission: https://leetcode.com/submissions/detail/385179793/
 */
public class P1557 {
    class Solution {
        public List<Integer> findSmallestSetOfVertices(int n, List<List<Integer>> edges) {
            var set = new HashSet<Integer>();

            for (var i = 0; i < n; i++)
                set.add(i);

            for (var edge : edges) {
                var dest = edge.get(1);
                if (set.contains(dest))
                    set.remove(dest);
            }

            var ans = new ArrayList<Integer>();

            for (var el : set)
                ans.add(el);

            return ans;
        }
    }
}
