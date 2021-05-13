package leetcode;

import java.util.ArrayList;
import java.util.List;
import java.util.PriorityQueue;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/sum-of-digits-in-base-k/
 * Submission: https://leetcode.com/submissions/detail/491272660/
 */
public class P1837 {
    class Solution {
        public int sumBase(int n, int k) {
            var digits = new ArrayList<Integer>();

            while (n > 0) {
                for (var power = 0; ; power++) {
                    if (Math.pow(k, power) <= n && n < Math.pow(k, power + 1)) {
                        var div = n / (int)Math.pow(k, power);
                        n = n - div * (int)Math.pow(k, power);
                        digits.add(div);
                        break;
                    }
                }
            }

            return digits.stream().collect(Collectors.summingInt(i -> i));
        }
    }
}