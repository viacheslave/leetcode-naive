namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/contest/biweekly-contest-41/problems/sum-of-absolute-differences-in-a-sorted-array/
  ///    Submission: https://leetcode.com/contest/biweekly-contest-41/submissions/detail/429867715/
  /// </summary>
  internal class P1685
  {
    public class Solution
    {
      public int[] GetSumAbsoluteDifferences(int[] nums)
      {
        var ans = new int[nums.Length];

        var left = 0;
        var right = 0;

        for (var i = 0; i < nums.Length; i++)
          left += nums[i] - nums[0];

        ans[0] = left;

        for (var i = 1; i < nums.Length; i++)
        {
          left = left - (nums.Length - i) * (nums[i] - nums[i - 1]);
          right = right + i * (nums[i] - nums[i - 1]);

          ans[i] = left + right;
        }

        return ans;
      }
    }
  }
}
