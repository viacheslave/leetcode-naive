package problems;

/*
 * Problem: https://leetcode.com/problems/rotate-function/
 * Submission: https://leetcode.com/submissions/detail/301706932/
 */
class P0396 {
    public int maxRotateFunction(int[] A) {
        if (A.length == 0)
            return 0;

        var max = Integer.MIN_VALUE;

        for (var i = 0; i < A.length; i++) {
            var sum = GetF(A, i, A.length);
            if (sum > max) max = sum;
        }

        return max;
    }

    public int GetF(int[] A, int index, int length) {
        var sum = 0;

        for (var coeff = 1; coeff < length; coeff++)
            sum += coeff * A[(index + coeff) % length];

        return sum;
    }
}