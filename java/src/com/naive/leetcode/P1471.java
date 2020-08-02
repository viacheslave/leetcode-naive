package com.naive.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;

/**
 * Problem: https://leetcode.com/problems/the-k-strongest-values-in-an-array/
 * Submission: https://leetcode.com/submissions/detail/375071653/
 */
public class P1471 {
    class Solution {
        public int[] getStrongest(int[] arr, int k) {
            Arrays.sort(arr);

            int median = arr[(arr.length - 1) / 2];

            Node[] posarr = new Node[arr.length];

            for (var i = 0; i < arr.length; i++) {
                posarr[i] = new Node();
                posarr[i].diff = Math.abs(arr[i] - median);
                posarr[i].value = arr[i];
            }

            Arrays.sort(posarr,
                    Comparator
                            .comparingInt(Node::getDiff)
                            .thenComparingInt(Node::getValue));

            ArrayList<Integer> ans = new ArrayList<>();

            for (int i = 0; i < k; i++) {
                if (i < posarr.length)
                    ans.add(posarr[posarr.length - i - 1].value);
                else
                    break;
            }

            return ans.stream().mapToInt(v -> v).toArray();
        }

        private class Node {
            public int value;
            public int diff;

            public int getDiff(){
                return this.diff;
            }

            public int getValue(){
                return this.value;
            }
        }
    }
}
