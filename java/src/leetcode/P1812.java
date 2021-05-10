package leetcode;

import java.util.ArrayList;
import java.util.List;
import java.util.PriorityQueue;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/determine-color-of-a-chessboard-square/
 * Submission: https://leetcode.com/submissions/detail/491202187/
 */
public class P1812 {
    class Solution {
        public boolean squareIsWhite(String coordinates) {
            var ch = (int)coordinates.charAt(0) + (int)coordinates.charAt(1);
            return ch % 2 == 1;
        }
    }
}