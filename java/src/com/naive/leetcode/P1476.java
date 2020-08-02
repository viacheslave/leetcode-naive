package com.naive.leetcode;

/**
 * Problem: https://leetcode.com/problems/subrectangle-queries/
 * Submission: https://leetcode.com/submissions/detail/374963660/
 */
public class P1476 {
    class SubrectangleQueries {

        private int[][] rectangle;

        public SubrectangleQueries(int[][] rectangle) {
            this.rectangle = rectangle;
        }

        public void updateSubrectangle(int row1, int col1, int row2, int col2, int newValue) {
            for (int row = row1; row <= row2; row++) {
                for (int col = col1; col <= col2; col++) {
                    this.rectangle[row][col] = newValue;
                }
            }
        }

        public int getValue(int row, int col) {
            return this.rectangle[row][col];
        }
    }

    /**
     * Your SubrectangleQueries object will be instantiated and called as such:
     * SubrectangleQueries obj = new SubrectangleQueries(rectangle);
     * obj.updateSubrectangle(row1,col1,row2,col2,newValue);
     * int param_2 = obj.getValue(row,col);
     */
}
