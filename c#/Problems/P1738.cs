namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-kth-largest-xor-coordinate-value/
  ///    Submission: https://leetcode.com/submissions/detail/448116296/
  /// </summary>
  internal class P1738
  {
    public class Solution
    {
      public int KthLargestValue(int[][] matrix, int k)
      {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        // build 2D prefix sums
        var prefixSums = new int[rows + 1, cols + 1];

        for (var row = 0; row < rows; ++row)
        {
          var prRow = new int[cols + 1];

          for (var col = 0; col < cols; ++col)
          {
            prRow[col + 1] = prRow[col] ^ matrix[row][col];
            prefixSums[row + 1, col + 1] = prefixSums[row, col + 1] ^ prRow[col] ^ matrix[row][col];
          }
        }

        // put them in array, and sort
        var arr = new int[rows * cols];

        for (var row = 0; row < rows; ++row)
          for (var col = 0; col < cols; ++col)
            arr[row * cols + col] = prefixSums[row + 1, col + 1];

        Array.Sort(arr);

        return arr[arr.Length - 1 - k + 1];
      }
    }
  }
}
