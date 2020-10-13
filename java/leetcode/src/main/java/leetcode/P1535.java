package leetcode;

import java.util.*;

/**
 * Problem: https://leetcode.com/problems/find-the-winner-of-an-array-game/
 * Submission: https://leetcode.com/submissions/detail/375078875/
 */
public class P1535 {
    class Solution {
        public int getWinner(int[] arr, int k) {

            int last = Integer.MIN_VALUE;
            int rounds = 0;

            List<Integer> list = new ArrayList<Integer>();
            for (int i = 0; i < arr.length; i++)
                list.add(arr[i]);

            if (k >= arr.length)
                return list.stream().max(Comparator.naturalOrder()).get().intValue();

            while (rounds < k) {
                var first = list.get(0);
                var second = list.get(1);

                int winner;

                if (first > second) {
                    winner = first;
                    list.remove(1);
                    list.add(second);
                } else {
                    winner = second;
                    list.remove(0);
                    list.add(first);
                }

                if (winner == last)
                    rounds++;
                else
                    rounds = 1;

                last = winner;
            }

            return last;
        }
    }
}
