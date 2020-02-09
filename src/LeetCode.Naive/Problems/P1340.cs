using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/jump-game-v/
	///		Submission: https://leetcode.com/submissions/detail/299640641/
	/// </summary>
	internal class P1340
	{
    public int MaxJumps(int[] arr, int d)
    {
      var dp = Enumerable.Repeat(-1, arr.Length).ToList();

      for (int i = 0; i < arr.Length; i++)
        dp[i] = GetDp(arr, d, i, dp);

      return dp.Max();
    }

    private int GetDp(int[] arr, int d, int i, List<int> dp)
    {
      if (dp[i] != -1)
        return dp[i];

      var max = 0;
      var localmax = arr[i];

      for (var index = i + 1; index <= i + d; index++)
      {
        if (index < 0 || index >= arr.Length)
          continue;

        if (arr[index] <= arr[i])
          continue;

        if (arr[index] <= localmax)
          continue;

        int dpindex = GetDp(arr, d, index, dp);
        dp[index] = dpindex;

        max = Math.Max(max, dpindex);
        localmax = arr[index];
      }

      localmax = arr[i];
      for (var index = i - 1; index >= i - d; index--)
      {
        if (index < 0 || index >= arr.Length)
          continue;

        if (arr[index] <= arr[i])
          continue;

        if (arr[index] <= localmax)
          continue;

        int dpindex = GetDp(arr, d, index, dp);
        dp[index] = dpindex;

        max = Math.Max(max, dpindex);
        localmax = arr[index];
      }

      return max + 1;
    }
  }
}
