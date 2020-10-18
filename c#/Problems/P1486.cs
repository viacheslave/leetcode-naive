namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/xor-operation-in-an-array/
  ///    Submission: https://leetcode.com/submissions/detail/387146392/
  /// </summary>
  internal class P1486
  {
    public class Solution
    {
      public int XorOperation(int n, int start)
      {
        var ans = 0;

        for (var i = 0; i < n; i++)
          ans ^= (start + 2 * i);

        return ans;
      }
    }
  }
}
