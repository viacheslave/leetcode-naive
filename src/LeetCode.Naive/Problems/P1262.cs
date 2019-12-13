using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/greatest-sum-divisible-by-three/
	///		Submission: https://leetcode.com/submissions/detail/285652419/
	/// </summary>
	internal class P1262
	{
    public int MaxSumDivThree(int[] nums)
    {
      var dp = new int[nums.Length + 1][];
      dp[0] = new int[3];

      for (int i = 0; i < nums.Length; i++)
      {
        dp[i + 1] = new int[3];

        dp[i + 1][0] = dp[i][0];
        dp[i + 1][1] = dp[i][1];
        dp[i + 1][2] = dp[i][2];

        var mod = nums[i] % 3;
        switch (mod)
        {
          case 0:
            dp[i + 1][0] = dp[i][0] + nums[i];

            if (dp[i][1] != 0)
              dp[i + 1][1] = dp[i][1] + nums[i];
            if (dp[i][2] != 0)
              dp[i + 1][2] = dp[i][2] + nums[i];

            break;

          case 1:
            if (dp[i][1] == 0)
              dp[i + 1][1] = nums[i];

            if (dp[i][2] != 0)
              dp[i + 1][0] = Math.Max(dp[i][0], dp[i][2] + nums[i]);

            if (dp[i][0] != 0)
              dp[i + 1][1] = Math.Max(dp[i][1], dp[i][0] + nums[i]);

            if (dp[i][1] != 0)
              dp[i + 1][2] = Math.Max(dp[i][2], dp[i][1] + nums[i]);

            break;

          case 2:
            if (dp[i][2] == 0)
              dp[i + 1][2] = nums[i];

            if (dp[i][1] != 0)
              dp[i + 1][0] = Math.Max(dp[i][0], dp[i][1] + nums[i]);

            if (dp[i][0] != 0)
              dp[i + 1][2] = Math.Max(dp[i][2], dp[i][0] + nums[i]);

            if (dp[i][2] != 0)
              dp[i + 1][1] = Math.Max(dp[i][1], dp[i][2] + nums[i]);

            break;
        }
      }

      return dp[nums.Length][0];
    }
  }
}
