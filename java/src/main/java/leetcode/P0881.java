package leetcode;

import java.util.*;

/**
 * Problem: https://leetcode.com/problems/boats-to-save-people/
 * Submission: https://leetcode.com/submissions/detail/397020372/
 */
public class P0881 {
    class Solution {
        public int numRescueBoats(int[] people, int limit) {
            Arrays.sort(people);

            var start = 0;
            var end = 0;

            var marked = new int[people.length];

            var ans = 0;
            while (true) {
                while (marked[start] == 1) {
                    start++;
                    if (start == people.length)
                        break;
                }

                if (end < start)
                    while (end < start)
                        end++;
                else
                    while (end > start && marked[end] == 1)
                        end--;

                if (start >= people.length)
                    break;

                if ((start == end && people[start] <= limit) || people[start] + people[end] <= limit) {
                    var current = end + 1;

                    while (true) {
                        if (current == people.length)
                            break;

                        if (marked[current] == 1) {
                            current++;
                            continue;
                        }

                        if ((start == current && people[start] <= limit) || people[start] + people[current] <= limit) {
                            end = current;
                            current++;
                            continue;
                        }

                        break;
                    }
                } else {
                    var current = end - 1;

                    while (true) {
                        if (current == start) {
                            end = current;
                            break;
                        }

                        if (marked[current] == 1) {
                            current--;
                            continue;
                        }

                        if (people[start] + people[current] <= limit) {
                            end = current;
                            break;
                        }

                        current--;
                    }
                }

                if (start == end) {
                    marked[start] = 1;
                }
                else {
                    marked[start] = 1;
                    marked[end] = 1;
                }

                ans++;
            }

            return ans;
        }
    }
}
