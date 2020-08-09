package com.naive.leetcode;

import java.util.HashMap;

/**
 * Problem: https://leetcode.com/problems/construct-k-palindrome-strings/
 * Submission: https://leetcode.com/submissions/detail/378345341/
 */
public class P1400 {
    class Solution {
        public boolean canConstruct(String s, int k) {
            if (k > s.length())
                return false;

            var map = new HashMap<Character, Integer>();

            for (var ch: s.toCharArray()) {
                map.putIfAbsent(ch, 0);
                map.put(ch, map.get(ch) + 1);
            }

            var oddCount = map
                    .entrySet()
                    .stream()
                    .filter(e -> e.getValue().intValue() % 2 == 1)
                    .count();

            if (oddCount > k)
                return false;

            return true;
        }
    }
}
