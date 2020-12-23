using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/split-array-largest-sum/
  ///    Submission: https://leetcode.com/submissions/detail/433798634/
  /// </summary>
  internal class P0410
  {
    public class Solution
    {
      public int SplitArray(int[] nums, int m)
      {
        var dp = new int[nums.Length, m + 1, nums.Length + 1];

        // pos
        // chunks
        // last chunk length

        for (var pos = 0; pos < nums.Length; pos++)
          for (var chunk = 0; chunk < m + 1; chunk++)
            for (var len = 0; len < nums.Length + 1; len++)
              dp[pos, chunk, len] = -1;

        dp[0, 0, 1] = 0;
        dp[0, 1, 0] = nums[0];

        var prefix = new int[nums.Length + 1];
        for (var i = 0; i < nums.Length; i++)
          prefix[i + 1] = prefix[i] + nums[i];

        // the idea is we decide what to do with current num[pos]:
        // we can mark it as the end of a chunk or
        // we can prolong current chunk

        for (var pos = 1; pos < nums.Length; pos++)
        {
          var chunks = Math.Min(pos, m - 1);

          for (var chunk = 0; chunk <= chunks; chunk++)
          {
            for (var len = 0; len <= pos - chunk; len++)
            {
              if (dp[pos - 1, chunk, len] == -1)
                continue;

              // prolong current chunk
              dp[pos, chunk, len + 1] = dp[pos - 1, chunk, len];

              // max sum is prev max sum or sum of item of the chunk we end
              var value = Math.Max(
                dp[pos - 1, chunk, len],
                prefix[pos + 1] - prefix[pos + 1 - len - 1]);

              // there can be many variants with same number of chunks
              // [1,2,3,4]: (1)(2,3,4), (1,2)(3,4) etc.
              // we choose the minimum value
              if (dp[pos, chunk + 1, 0] == -1)
                dp[pos, chunk + 1, 0] = value;
              else
                dp[pos, chunk + 1, 0] = Math.Min(dp[pos, chunk + 1, 0], value);
            }
          }
        }

        return dp[nums.Length - 1, m, 0];
      }
    }
  }
}
