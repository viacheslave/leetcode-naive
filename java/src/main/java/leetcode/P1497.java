package leetcode;

import java.util.HashMap;

/**
 * Problem: https://leetcode.com/problems/check-if-array-pairs-are-divisible-by-k/
 * Submission: https://leetcode.com/submissions/detail/374961018/
 */
public class P1497 {
    class Solution {
        public boolean canArrange(int[] arr, int k) {
            var map = new HashMap<Integer, Integer>();

            for (var el: arr) {
                var key = (el + k) % k;
                if (el < 0)
                    key = (k - ((k - el) % k)) % k;

                map.putIfAbsent(key, 0);
                map.put(key, map.get(key) + 1);
            }

            for (var key : map.keySet()) {
                var otherkey = k - key;

                if (key == 0 || key == otherkey)
                {
                    if (map.get(key) % 2 == 1)
                        return false;
                    else
                        continue;
                }

                if (!map.containsKey(otherkey))
                    return false;

                if (map.get(key).intValue() != map.get(otherkey).intValue())
                    return false;
            }

            return true;
        }
    }
}
